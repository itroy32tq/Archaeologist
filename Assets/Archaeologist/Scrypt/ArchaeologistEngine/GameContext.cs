using ArchaeologistCore;
using UnityEngine;

namespace ArchaeologistEngine
{
    public sealed class GameContext
    {
        private int _needToVictory;
        private IRewardsBagPresenter _rewardsBagPresenter;

        public GameContext(RewardConfig config, IRewardsBagPresenter bagPresenter)
        {
            _needToVictory = config.RewardsCountNeed;
        }

        internal void CheckStatus()
        {
            var value = _rewardsBagPresenter.CurrentCount.Value;

            if (value >= _needToVictory) 
            {
                Debug.Log("!!!");
            }
        }
    }
}
