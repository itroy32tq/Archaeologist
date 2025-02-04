using ArchaeologistCore;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace ArchaeologistUI
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;
        [SerializeField] private Image _icon;
        private IPlayerPresenter _presenter;
        private readonly CompositeDisposable _disposable = new();

        [Inject]
        public void Init(IPlayerPresenter presenter)
        {
            _presenter = presenter;

            _presenter.ShovelCount.Subscribe(UpdatePlayerView).AddTo(_disposable);

            _icon.sprite = presenter.ShovelSprit;
        }

        private void UpdatePlayerView(int value)
        {
            _count.text = value.ToString();
        }
    }
}
