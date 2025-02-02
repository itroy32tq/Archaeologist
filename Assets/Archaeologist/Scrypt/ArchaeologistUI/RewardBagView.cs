using ArchaeologistCore;
using System;
using TMPro;
using UniRx;
using UnityEngine;
using Zenject;

namespace ArchaeologistUI
{
    public sealed class RewardBagView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _count;

        private IRewardsBagPresenter _presenter;
        private readonly CompositeDisposable _disposable = new();

        [Inject]
        public void Init(IRewardsBagPresenter presenter)
        { 
            _presenter = presenter;

            _presenter.CurrentCount.Subscribe(UpdateRewardView).AddTo(_disposable);

        }

        private void UpdateRewardView(int value)
        {
            _count.text = _presenter.CurrentCount.Value.ToString();
        }

        internal void AcceptReward(RewardView rewardView)
        {
            _presenter?.AcceptReward.Execute(Unit.Default);
        }
    }
}
