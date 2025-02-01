using UniRx;

namespace ArchaeologistCore
{
    public interface IPlayerPresenter
    {
        IReadOnlyReactiveProperty<int> ShovelCount { get; }

        void OnShovelCountChanged(int obj);
        void TakeExcavate();
    }
}