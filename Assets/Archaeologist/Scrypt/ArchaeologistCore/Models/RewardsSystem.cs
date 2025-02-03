using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

namespace ArchaeologistCore
{
    public sealed class RewardsSystem : IRewardsSystem, IInitializable, IDisposable
    {
        private readonly float _chance;
        private readonly RewardConfig _config;
        private readonly System.Random _random = new();
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

        }

        private void OnCellClickHandler(ICellPresenter cell)
        {
            Debug.Log("система клик получила");

            if (!Check(_chance))
            {
                return;
            }

            Debug.Log("бросок костей");

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

            _gridPresenter.OnPresenterClicked -= OnCellClickHandler;

            _disposable.Dispose();
        }

        public void Initialize()
        {
            _gridPresenter.OnPresenterClicked += OnCellClickHandler;
        }
    }
}
