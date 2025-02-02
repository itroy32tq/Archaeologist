using ArchaeologistCore;
using UniRx;
using UnityEngine;

namespace ArchaeologistUI
{
    public sealed class RewardView : MonoBehaviour
    {
        private bool isDragging = false;
        private IRewardPresenter _rewardPresenter;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private readonly CompositeDisposable _disposable = new();

        public void Init(IRewardPresenter presenter)
        {
            _rewardPresenter = presenter;

            _spriteRenderer.sprite = _rewardPresenter.Sprite;

            _rewardPresenter.IsCollected.Subscribe(OnCollected).AddTo(_disposable);
        }

        private void OnCollected(bool value)
        {
            if (value)
            { 
                gameObject.SetActive(false);
            }

        }

        void OnMouseDown()
        {
            isDragging = true;
        }

        void OnMouseDrag()
        {
            if (isDragging)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0; 
                transform.position = mousePosition;
            }
        }

        void OnMouseUp()
        {
            isDragging = false;

            Collider2D hit = Physics2D.OverlapPoint(transform.position);

            if (hit != null && hit.GetComponent<RewardBagView>() != null)
            {
                hit.GetComponent<RewardBagView>().AcceptReward(this);

                _rewardPresenter.OnDragToBag.Execute(Unit.Default);
            }
        }
    }
}
