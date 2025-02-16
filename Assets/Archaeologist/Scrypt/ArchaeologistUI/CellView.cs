using ArchaeologistCore;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UniRx;
using UnityEngine;

namespace ArchaeologistUI
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private TextMeshPro _layer;
        private ICellPresenter _cellPresenter;
        private readonly CompositeDisposable _disposable = new();


        public void Init(ICellPresenter presenter)
        {
            _cellPresenter = presenter;

            _cellPresenter.Layer.Subscribe(UpdateCellView).AddTo(_disposable);


            _cellPresenter.RequestBounce = async (onComplete) =>
            {
                await BaunceOnClickAnimationTask();

                await onComplete();
            };

        }

        private void UpdateCellView(int layer)
        {
            _spriteRenderer.sprite = _cellPresenter.Sprite;

            _layer.text = layer.ToString();
        }

        public void OnMouseDown()
        {
            Debug.Log($"���� �� ������: {_cellPresenter.X} , {_cellPresenter.Y}");

            _cellPresenter?.OnClick.Execute(Unit.Default);
        }
       

        public UniTask BaunceOnClickAnimationTask()
        {

            float _duration = 0.45f;

            UniTaskCompletionSource tcs = new();

            var anim = DOTween.Sequence()
                .Append(transform
                .DOScale(Vector3.one * 1.1f, _duration)
                .SetLoops(2, LoopType.Yoyo))
                .OnComplete(() =>
                {
                    tcs.TrySetResult();
                });

            return tcs.Task;
        }

    }
}

