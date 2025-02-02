using System;
using System.Collections.Generic;
using UniRx;

namespace ArchaeologistCore
{
    public sealed class RewardsSystem : IRewardsSystem, IDisposable
    {
        private readonly float _chance;
        private readonly RewardConfig _config;
        private readonly Random _random = new();
        private readonly IGridPresenter _gridPresenter;
        private readonly CompositeDisposable _disposable = new();
        private readonly ReactiveCollection<IRewardPresenter> _rewards = new();
        private readonly List<(IRewardPresenter, Action<IRewardPresenter>)> _actons = new();
        

        public event Action<IRewardPresenter> OnRewardCollected = delegate { };
        public IReadOnlyReactiveCollection<IRewardPresenter> Rewards => _rewards;

        public RewardsSystem(IGridPresenter gridPresenter, RewardConfig config)
        {
            _gridPresenter = gridPresenter;
            _config = config;

            _chance = _config.RewardChance;

            _gridPresenter.OnPresenterClicked += OnCellClickHandler;
        }

        private void OnCellClickHandler(ICellPresenter cell)
        {
            if (!Check(_chance))
            {
                return;
            }

            var reward = new Reward(cell.X, cell.Y);

            var presenter = new RewardPresenter(reward, _config);

            presenter.OnRewardCollected += OnRewardPresenterCollectedHandler;

            _actons.Add((presenter, OnRewardPresenterCollectedHandler));

            _rewards.Add(presenter);
        }

        private void OnRewardPresenterCollectedHandler(IRewardPresenter presenter)
        {
            OnRewardCollected.Invoke(presenter);
        }

        public bool TryRemoveReward(IRewardPresenter presenter)
        {
            return _rewards.Remove(presenter);
        }

        public bool Check(float chance)
        {
            return _random.NextDouble() < chance;
        }

        public void Dispose()
        {
            foreach (var (presenter, handler) in _actons)
            {
                presenter.OnRewardCollected -= handler;
            }

            _actons.Clear();

            _disposable.Dispose();
        }
    }
}
