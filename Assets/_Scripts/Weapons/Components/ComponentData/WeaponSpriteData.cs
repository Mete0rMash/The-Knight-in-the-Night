using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMA
{
    public class WeaponSpriteData : ComponentData
    {
        [field: SerializeField] public AttackSprites[] AttackData { get; private set; }
    }
}
