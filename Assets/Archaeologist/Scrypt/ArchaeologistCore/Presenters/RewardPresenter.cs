using System;
using UniRx;
using UnityEngine;

namespace ArchaeologistCore
{
    public sealed class RewardPresenter : IRewardPresenter
    {
        private readonly Reward _reward;
        private readonly RewardConfig _config;
        private readonly ReactiveProperty<bool> _isCollected;
        private readonly CompositeDisposable _disposable = new();

        public int X => _reward.X;
        public int Y => _reward.Y;
        public Sprite Sprite => _config.RewardSprite;
        public event Action<IRewardPresenter> OnRewardCollected = delegate { };
        public IReadOnlyReactiveProperty<bool> IsCollected => _isCollected;

        

        public ReactiveCommand<Unit> OnDragToBag { get; } = new ReactiveCommand<Unit>();

        public RewardPresenter(Reward reward, RewardConfig config)
        {
            _reward = reward;
            _config = config;

            _isCollected = new ReactiveProperty<bool>(reward.IsCollected);

            _isCollected.Subscribe(OnRewardCollectedHandler).
                AddTo(_disposable);

            OnDragToBag.Subscribe(OnDragToBagHandler).AddTo(_disposable);
        }

        private void OnDragToBagHandler(Unit unit)
        {
            _isCollected.Value = true;
            _reward.SetCollectedStatus(true);
        }

        private void OnRewardCollectedHandler(bool value)
        {
            OnRewardCollected.Invoke(this);
        }
    }
}
