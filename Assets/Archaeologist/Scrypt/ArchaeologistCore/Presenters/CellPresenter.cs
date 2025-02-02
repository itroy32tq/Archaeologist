using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UnityEngine;

namespace ArchaeologistCore
{
    public sealed class CellPresenter : ICellPresenter
    {
        private readonly Cell _cell;
        private readonly CellConfig _config;
        private readonly ReactiveProperty<int> _layer;
        private readonly CompositeDisposable _disposable = new();

        public int X => _cell.X;
        public int Y => _cell.Y;
        public Subject<UniTask> OnBounceRequested { get; }
        public IReadOnlyReactiveProperty<int> Layer => _layer;
        public Sprite Sprite => _config.Sprites[_layer.Value];
        
        public event Action<ICellPresenter> OnCellClicked = delegate { };
        public ReactiveCommand<Unit> OnClick { get; } = new ReactiveCommand<Unit>();

        public CellPresenter(Cell cell, CellConfig config)
        {
            _cell = cell;
            _config = config;

            _layer = new ReactiveProperty<int>(_cell.Layer);

            if (_layer.Value != _config.Sprites.Length)
            {
                throw new Exception();
            }

            _layer.Subscribe(OnLayerChanged).
                AddTo(_disposable);

            OnClick.Subscribe(OnViewClicked).AddTo(_disposable);

        }

        private void OnViewClicked(Unit unit)
        {
            
            TakePeel();

        }

        public async UniTask RequestBounce()
        {
            if (OnBounceRequested.HasObservers)
            {
                await OnBounceRequested.First();
            }     
        }

        public void OnLayerChanged(int layer)
        {
            throw new NotImplementedException();
        }

        public void TakePeel()
        {
            if (_layer.Value > 0)
            {
                _layer.Value --;

                _cell.Peel();

                OnCellClicked.Invoke(this);
            }
        }
    }
}
