using System;
using UniRx;
using UnityEngine;

namespace ArchaeologistCore
{
    public interface IRewardPresenter
    {
        IReadOnlyReactiveProperty<bool> IsCollected { get; }
        Sprite Sprite { get; }
        int X { get; }
        int Y { get; }
        ReactiveCommand<Unit> OnDragToBag { get; }

        event Action<IRewardPresenter> OnRewardCollected;
    }
}