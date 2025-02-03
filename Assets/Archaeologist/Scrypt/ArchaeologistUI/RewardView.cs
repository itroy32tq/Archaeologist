using ArchaeologistCore;
using DG.Tweening;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ArchaeologistUI
{
    public sealed class RewardView : MonoBehaviour
    {
        private Vector3 _startPosition;
        private bool isDragging = false;
        private IRewardPresenter _rewardPresenter;

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private readonly CompositeDisposable _disposable = new();

        public void Init(IRewardPresenter presenter)
        {
            _startPosition = transform.position;

            _rewardPresenter = presenter;

            _spriteRenderer.sprite = _rewardPresenter.Sprite;

            _rewardPresenter.IsCollected.Subscribe(OnCollected).AddTo(_disposable);
        }

        //по хорошему надо делать пул, но няма часу
        private void OnCollected(bool value)
        {
            if (value)
            { 
                gameObject.SetActive(false);
            }

        }

        private void OnMouseDown()
        {
            isDragging = true;
        }

        private void OnMouseDrag()
        {
            if (isDragging)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; 
                transform.position = mousePosition;
            }
        }

        private bool IsPointerOverUIElement()
        {
            PointerEventData eventData = new(EventSystem.current)
            {
                position = Input.mousePosition
            };

            List<RaycastResult> results = new();

            EventSystem.current.RaycastAll(eventData, results);

            return results.Count > 0;
        }

        private void OnMouseUp()
        {
            isDragging = false;

            if (IsPointerOverUIElement())
            {
                RewardBagView rewardBag = FindObjectOfType<RewardBagView>();

                if (rewardBag != null)
                {
                    rewardBag.AcceptReward(this);

                    _rewardPresenter.OnDragToBag.Execute(Unit.Default);

                    return;
                }
            }
            else 
            {
                transform.DOMove(_startPosition, 0.3f)
                     .SetEase(Ease.OutBack);
            }
        }
    }
}
