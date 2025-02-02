using UnityEngine;

namespace ArchaeologistCore
{
    [CreateAssetMenu(fileName = "GridConfig", menuName = "Configs/New GridConfig")]
    public sealed class GridConfig : ScriptableObject
    {
        [field: SerializeField] public int GridSize { get; private set; }
        [field: SerializeField] public int MaxLayers { get; private set; }
    }
}
