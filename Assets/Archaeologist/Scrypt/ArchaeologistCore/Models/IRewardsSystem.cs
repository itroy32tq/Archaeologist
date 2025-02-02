using System;
using UniRx;

namespace ArchaeologistCore
{
    public interface IRewardsSystem
    {
        IReadOnlyReactiveCollection<IRewardPresenter> Rewards { get; }

        event Action<IRewardPresenter> OnRewardCollected;

        bool Check(float chance);
        bool TryRemoveReward(IRewardPresenter presenter);
    }
}