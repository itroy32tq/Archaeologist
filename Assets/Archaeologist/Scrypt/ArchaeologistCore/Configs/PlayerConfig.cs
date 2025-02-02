using UnityEngine;

namespace ArchaeologistCore
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/New PlayerConfig")]
    public sealed class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public Sprite ShovelSprite { get; private set; }
        [field: SerializeField] public int ShovelCount { get; private set; }
    }
}
