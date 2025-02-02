using System;
using UniRx;
using UnityEngine;

namespace ArchaeologistCore
{
    public sealed class PlayerPresenter : IPlayerPresenter
    {
        private readonly Player _player;
        private readonly PlayerConfig _playerConfig;
        private readonly ReactiveProperty<int> _shovelCount;
        private readonly CompositeDisposable _disposable = new();
        public Sprite ShovelSprit => _playerConfig.ShovelSprite;

        public IReadOnlyReactiveProperty<int> ShovelCount => _shovelCount;

        public PlayerPresenter(Player player, PlayerConfig config)
        {
            _player = player;
            _playerConfig = config;

            _shovelCount = new ReactiveProperty<int>(_player.ShovelCount);
            _shovelCount.Subscribe(OnShovelCountChanged).
                AddTo(_disposable);
        }

        public void OnShovelCountChanged(int obj)
        {
            throw new NotImplementedException();
        }

        public void TakeExcavate()
        {
            if (_shovelCount.Value > 0)
            {
                _shovelCount.Value--;

                _player.Excavate();
            }
            else
            {
                //todo
            }
        }
    }
}
