using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ArchaeologistCore
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/New PlayerConfig")]
    public sealed class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public Sprite ShovelSprit { get; private set; }
    }
}
