using System;
using UniRx;

namespace ArchaeologistCore
{
    public class RewardsBagPresenter
    {
        private readonly RewardsBag _bug;
        private readonly ReactiveProperty<int> _currentCount;
        public IReadOnlyReactiveProperty<int> CurrentCount => _currentCount;
        private readonly CompositeDisposable _disposable = new();

        public RewardsBagPresenter(RewardsBag rewardsBag)
        {
            _bug = rewardsBag;

            _currentCount = new ReactiveProperty<int>(_bug.CurrentCount);

            _currentCount.Subscribe(OnRewardsChanged).
                AddTo(_disposable);
        }

        private void OnRewardsChanged(int obj)
        {
            throw new NotImplementedException();
        }
    }
}
