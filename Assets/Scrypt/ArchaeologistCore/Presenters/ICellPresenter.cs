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

        ExcavateResult TakePeel();
        void OnLayerChanged(int layer);
    }
}