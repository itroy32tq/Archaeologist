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
        public Func<Func<UniTask>, UniTask> RequestBounce { get; set; }
        public IReadOnlyReactiveProperty<int> Layer => _layer;
        public Sprite Sprite => _config.Sprites[_layer.Value - 1];
        
        public event Action<ICellPresenter> OnCellClicked = delegate { };
        public ReactiveCommand<Unit> OnClick { get; } = new ReactiveCommand<Unit>();

        public CellPresenter(Cell cell, CellConfig config)
        {
            _cell = cell;

            _config = config;

            _layer = new ReactiveProperty<int>(_cell.Layer);

            if (_layer.Value > _config.Sprites.Length)
            {
                throw new Exception();
            }

            _layer.Subscribe(OnLayerChanged).
                AddTo(_disposable);

            OnClick.Subscribe(OnViewClicked).AddTo(_disposable);

        }

        private void OnViewClicked(Unit unit)
        {

            //Debug.Log($" Презентер клик получил : {X} , {Y}");

            TakePeel();
        }

        public async UniTask ExecuteBounce()
        {
            await RequestBounce(() => UniTask.CompletedTask);
        }

        public void OnLayerChanged(int layer)
        {
            Debug.Log(layer);
        }

        public void TakePeel()
        {
            if (_layer.Value > 1)
            {
                _layer.Value--;

                _cell.Peel();

                OnCellClicked.Invoke(this);
            }
            else 
            {
                Debug.Log($" клик по 1 слою, можно подумать как обрабатывать : {X} , {Y}");
            }
        }
    }
}
