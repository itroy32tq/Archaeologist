using UniRx;

namespace ArchaeologistCore
{
    public interface IRewardsBagPresenter
    {
        IReadOnlyReactiveProperty<int> CurrentCount { get; }

        void OnRewardsChanged(int obj);
    }
}