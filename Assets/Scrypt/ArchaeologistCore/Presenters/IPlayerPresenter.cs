using UniRx;
using UnityEngine;

namespace ArchaeologistCore
{
    public interface IPlayerPresenter
    {
        IReadOnlyReactiveProperty<int> ShovelCount { get; }
        Sprite ShovelSprit { get; }

        void OnShovelCountChanged(int obj);
        void TakeExcavate();
    }
}