using UnityEngine;

namespace ArchaeologistCore
{
    [CreateAssetMenu(fileName = "RewardConfig", menuName = "Configs/New RewardConfig")]
    public sealed class RewardConfig : ScriptableObject
    {
        [field: SerializeField] public Sprite RewardSprite { get; private set; }
        [field: SerializeField] public float RewardChance { get; private set; }
        [field: SerializeField] public int RewardsCountNeed { get; private set; }
        [field: SerializeField] public int RewardsBugCapacity { get; private set; }
    }
}
