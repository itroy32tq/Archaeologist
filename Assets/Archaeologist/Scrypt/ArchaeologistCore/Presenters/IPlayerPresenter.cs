using UniRx;
using UnityEngine;

namespace ArchaeologistCore
{
    public interface IPlayerPresenter
    {
        IReadOnlyReactiveProperty<int> ShovelCount { get; }
        Sprite ShovelSprit { get; }

        void LoadData(PlayerData data);
        void OnShovelCountChanged(int obj);
        void TakeExcavate();
    }
}