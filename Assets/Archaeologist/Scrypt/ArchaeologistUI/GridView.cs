using ArchaeologistCore;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ArchaeologistUI
{
    public sealed class GridView : MonoBehaviour, IInitializable
    {
        [SerializeField] CellView _cellPrefab;

        private readonly Dictionary<(int x, int Y), Vector3> _gridMap = new();

        private IGridPresenter _presenter;
        private GridConfig _config;

        [Inject]
        public void Init(IGridPresenter presenter, GridConfig config) 
        {
            _presenter = presenter;
            _config = config;

            if (_cellPrefab == null)
            {
                Debug.LogError("Cell Prefab не установлен!");

                return;
            }

            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }

        public bool TryGetPositionForCoordinate(int x, int y, out Vector3 position)
        {
            if (_gridMap.TryGetValue((x, y), out var value))
            {
                position = value;
                return true;
            }

            position = default;

            return false;
        }

        public void Initialize()
        {
            Vector2 cellSize = new(1.4f, 1.5f);

            var gridSize = _config.GridSize;

            float offsetX = (gridSize - 1) * cellSize.x * 0.5f;
            float offsetY = (gridSize - 1) * cellSize.y * 0.5f;

            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    Vector3 position = new(x * cellSize.x - offsetX, y * cellSize.y - offsetY, 0);

                    _gridMap.Add((x, y), position);

                    var view = Instantiate(_cellPrefab, position, Quaternion.identity, transform);

                    view.Init(_presenter.GetPresenter(x, y));

                }
            }
        }
    }
}
