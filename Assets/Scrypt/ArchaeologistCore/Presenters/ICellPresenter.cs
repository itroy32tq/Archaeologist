using UniRx;

namespace ArchaeologistCore
{
    public interface ICellPresenter
    {
        IReadOnlyReactiveProperty<int> Layer { get; }
        int X { get; }
        int Y { get; }
        ExcavateResult TakePeel();
        void OnLayerChanged(int layer);
    }
}