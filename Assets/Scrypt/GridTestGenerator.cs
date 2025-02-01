using UnityEngine;

public class GridTestGenerator : MonoBehaviour
{
    public GameObject cellPrefab;
    public Transform gridParent;
    public int gridSize = 10;
    public float cellSize;


    [ContextMenu("Generate Grid")]
    void GenerateGrid()
    {
        if (cellPrefab == null)
        {
            Debug.LogError("Cell Prefab не установлен!");
            return;
        }

        foreach (Transform child in gridParent)
        {
            DestroyImmediate(child.gameObject);
        }

        Vector2 cellSize = GetCellSize();

        float offsetX = (gridSize - 1) * cellSize.x * 0.5f;
        float offsetY = (gridSize - 1) * cellSize.y * 0.5f;

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                Vector3 position = new(x * cellSize.x - offsetX, y * cellSize.y - offsetY, 0);
                Instantiate(cellPrefab, position, Quaternion.identity, transform);
            }
        }
    }

    Vector2 GetCellSize()
    {
        if (cellPrefab.GetComponent<SpriteRenderer>() != null)
        {
            SpriteRenderer spriteRenderer = cellPrefab.GetComponent<SpriteRenderer>();
            return spriteRenderer.bounds.size;
        }
        else if (cellPrefab.GetComponent<MeshRenderer>() != null)
        {
            MeshRenderer meshRenderer = cellPrefab.GetComponent<MeshRenderer>();
            return new Vector2(meshRenderer.bounds.size.x, meshRenderer.bounds.size.y);
        }

        Debug.LogWarning("Не удалось определить размер ячейки, используем (1,1)");
        return new Vector2(1, 1);
    }
}
