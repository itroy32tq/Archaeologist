using UnityEngine;

namespace ArchaeologistCore
{
    [CreateAssetMenu(fileName = "CellConfig", menuName = "Configs/New CellConfig")]
    public sealed class CellConfig : ScriptableObject
    {
        [field: SerializeField] public Sprite[] Sprites { get; private set; } = new Sprite[0];
    }
}
