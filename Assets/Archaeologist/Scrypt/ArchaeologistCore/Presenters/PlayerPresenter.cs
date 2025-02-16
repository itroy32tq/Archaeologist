﻿using System;
using UniRx;
using UnityEngine;
using Zenject;

namespace ArchaeologistCore
{
    public sealed class PlayerPresenter : IPlayerPresenter, IInitializable, IDisposable
    {
        private readonly Player _player;
        private readonly PlayerConfig _playerConfig;
        private readonly IGridPresenter _gridPresenter;
        private readonly ReactiveProperty<int> _shovelCount;
        private readonly CompositeDisposable _disposable = new();
        public Sprite ShovelSprit => _playerConfig.ShovelSprite;

        public IReadOnlyReactiveProperty<int> ShovelCount => _shovelCount;

        public PlayerPresenter(Player player, PlayerConfig config, IGridPresenter gridPresenter)
        {
            _player = player;

            _playerConfig = config;

            _shovelCount = new ReactiveProperty<int>(_player.ShovelCount);

            _shovelCount.Subscribe(OnShovelCountChanged).
                AddTo(_disposable);

            _gridPresenter = gridPresenter;
        }

        public void OnShovelCountChanged(int obj)
        {
            Debug.Log($" измнилось количество лопаток у игрока - {obj}");
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

        public void LoadData(PlayerData data)
        {
            _shovelCount.Value = data.ShovelCount;
        }

        public void Initialize()
        {
            _gridPresenter.OnPresenterClicked += OnPresenterClickHandler;
        }

        private void OnPresenterClickHandler(ICellPresenter presenter)
        {
            TakeExcavate();
        }

        public void Dispose()
        {
            _gridPresenter.OnPresenterClicked -= OnPresenterClickHandler;
        }
    }
}
