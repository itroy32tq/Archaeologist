using UniRx;

namespace ArchaeologistCore
{
    public interface IRewardsBagPresenter
    {
        IReadOnlyReactiveProperty<int> CurrentCount { get; }
        ReactiveCommand<Unit> AcceptReward { get; }

        void OnRewardsChanged(int obj);
    }
}