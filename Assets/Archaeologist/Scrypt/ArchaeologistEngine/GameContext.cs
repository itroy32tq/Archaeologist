using ArchaeologistCore;
using System;
using UniRx;
using UnityEditor;
using UnityEngine;

namespace ArchaeologistEngine
{
    public sealed class GameContext
    {
        private readonly int _needToVictory;
        private readonly IRewardsBagPresenter _rewardsBagPresenter;
        private readonly CompositeDisposable _disposable = new();

        public GameContext(RewardConfig config, IRewardsBagPresenter bagPresenter)
        {
            _needToVictory = config.RewardsCountNeed;

            _rewardsBagPresenter = bagPresenter;

            _rewardsBagPresenter.CurrentCount.Subscribe(CheckRewardsCount).AddTo(_disposable);
        }

        private void CheckRewardsCount(int value)
        {
            if (value >= _needToVictory)
            {
                EditorApplication.isPaused = true;

                Debug.Log(" игра окончена ");
            }
        }
    }
}
