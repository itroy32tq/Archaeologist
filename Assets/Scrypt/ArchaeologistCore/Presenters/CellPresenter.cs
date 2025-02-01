using System;
using UniRx;
using UnityEngine;

namespace ArchaeologistCore
{
    public sealed class CellPresenter : ICellPresenter
    {
        private readonly Cell _cell;
        private readonly CellConfig _config;
        public int X => _cell.X;
        public int Y => _cell.Y;

        private readonly ReactiveProperty<int> _layer;
        public IReadOnlyReactiveProperty<int> Layer => _layer;
        public Sprite Sprite => _config.Sprites[_layer.Value];
        public string LayerNum => Layer.Value.ToString();

        private readonly CompositeDisposable _disposable = new();

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
        }

        public void OnLayerChanged(int layer)
        {
            throw new NotImplementedException();
        }

        public ExcavateResult TakePeel()
        {
            if (_layer.Value > 0)
            {
                _layer.Value --;

                _cell.Peel();
            }

            return _layer.Value switch
            {
                0 => ExcavateResult.none,
                _ => ExcavateResult.success,
            };
        }
    }
}
