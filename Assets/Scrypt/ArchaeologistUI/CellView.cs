using ArchaeologistCore;
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

            UpdateCellView(_cellPresenter.Layer.Value);

        }

        private void UpdateCellView(int layer)
        {
            _spriteRenderer.sprite = _cellPresenter.Sprite;

            _layer.text = layer.ToString();
        }

        public void OnMouseDown()
        {
            Debug.Log($"Клик по клетке: {gameObject.name}");

            _cellPresenter?.OnClick.Execute(Unit.Default);
        }


    }
}

