using ArchaeologistCore;
using UnityEngine;
using Zenject;

namespace ArchaeologistUI
{
    public sealed class GridView : MonoBehaviour
    {
        [SerializeField] CellView _cellPrefab;

        [Inject]
        public void Init(IGridPresenter presenter, GridConfig config) 
        {
            if (_cellPrefab == null)
            {
                Debug.LogError("Cell Prefab не установлен!");

                return;
            }

            foreach (Transform child in transform)
            {
                DestroyImmediate(child.gameObject);
            }

            Vector2 cellSize = GetCellSize();

            var gridSize = config.GridSize;

            float offsetX = (gridSize - 1) * cellSize.x * 0.5f;
            float offsetY = (gridSize - 1) * cellSize.y * 0.5f;

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    Vector3 position = new(x * cellSize.x - offsetX, y * cellSize.y - offsetY, 0);

                    var view = Instantiate(_cellPrefab, position, Quaternion.identity, transform);

                    view.Init(presenter.GetPresenter(x,y));

                }
            }
        }

        Vector2 GetCellSize()
        {
            if (_cellPrefab.GetComponent<SpriteRenderer>() != null)
            {
                SpriteRenderer spriteRenderer = _cellPrefab.GetComponent<SpriteRenderer>();
                return spriteRenderer.bounds.size;
            }
            else if (_cellPrefab.GetComponent<MeshRenderer>() != null)
            {
                MeshRenderer meshRenderer = _cellPrefab.GetComponent<MeshRenderer>();
                return new Vector2(meshRenderer.bounds.size.x, meshRenderer.bounds.size.y);
            }

            Debug.LogWarning("Не удалось определить размер ячейки, используем (1,1)");

            return new Vector2(1, 1);
        }
    }
}
