using System;
using UniRx;
using UnityEngine;

namespace ArchaeologistCore
{
    public interface ICellPresenter
    {
        IReadOnlyReactiveProperty<int> Layer { get; }
        int X { get; }
        int Y { get; }
        Sprite Sprite { get; }

        ReactiveCommand<Unit> OnClick { get; }

        event Action<ICellPresenter> OnCellClicked;

        ExcavateResult TakePeel();
        void OnLayerChanged(int layer);
    }
}