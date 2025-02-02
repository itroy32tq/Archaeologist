using ArchaeologistCore;
using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace ArchaeologistUI
{
    public sealed class RewardsController : MonoBehaviour
    {
        
        private GridView _gridView;
        private IRewardsSystem _rewardsSystem;
        [SerializeField] RewardView _rewardPrefab;
        private readonly CompositeDisposable _disposable = new();

        [Inject]
        public void Init(IRewardsSystem rewardsSystem, GridView gridView)
        { 
            _rewardsSystem = rewardsSystem;
            _gridView = gridView;

            _rewardsSystem.Rewards.ObserveAdd().Subscribe(OnRewardAdded).AddTo(_disposable);

            _rewardsSystem.Rewards.ObserveRemove().Subscribe(OnRewardRemove).AddTo(_disposable);
        }

        private void OnRewardRemove(CollectionRemoveEvent<IRewardPresenter> @event)
        {
            throw new NotImplementedException();
        }

        private void OnRewardAdded(CollectionAddEvent<IRewardPresenter> data)
        {
            var reward = data.Value;

            if (_gridView.TryGetPositionForCoordinate(reward.X, reward.Y, out var position))
            {
                var view = Instantiate(_rewardPrefab, position, Quaternion.identity, transform);

                view.Init(reward);
            }

            throw new Exception();

        }
    }
}
