using Cysharp.Threading.Tasks;
using System;
using UniRx;
using UnityEngine;

namespace ArchaeologistCore
{
    public interface ICellPresenter
    {
        IReadOnlyReactiveProperty<int> Layer { get; }
        int X { get; }
        int Y { get; }
        Sprite Sprite { get; }
        ReactiveCommand<Unit> OnClick { get; }
        Func<Func<UniTask>, UniTask> RequestBounce { get; set; }

        event Action<ICellPresenter> OnCellClicked;

        void TakePeel();
        void OnLayerChanged(int layer);
        UniTask ExecuteBounce();
    }
}