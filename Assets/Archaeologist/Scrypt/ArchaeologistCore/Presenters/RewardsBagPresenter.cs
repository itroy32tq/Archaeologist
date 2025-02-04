using UniRx;

namespace ArchaeologistCore
{
    public class RewardsBagPresenter : IRewardsBagPresenter
    {
        private readonly RewardsBag _bug;
        private readonly ReactiveProperty<int> _currentCount;
        private readonly CompositeDisposable _disposable = new();
        public IReadOnlyReactiveProperty<int> CurrentCount => _currentCount;
        public ReactiveCommand<Unit> AcceptReward { get; } = new ReactiveCommand<Unit>();
        

        public RewardsBagPresenter(RewardsBag rewardsBag)
        {
            _bug = rewardsBag;

            _currentCount = new ReactiveProperty<int>(_bug.CurrentCount);

            _currentCount.Subscribe(OnRewardsChanged).
                AddTo(_disposable);

            AcceptReward.Subscribe(OnBagAccepted).AddTo(_disposable);
        }

        private void OnBagAccepted(Unit unit)
        {
            _currentCount.Value++;
        }

        public void OnRewardsChanged(int obj)
        {
            _bug.IncRewardCount();
        }

        public void LoadData(RewardsBagData data)
        {
            _currentCount.Value = data.CurrentCount;
        }
    }
}
