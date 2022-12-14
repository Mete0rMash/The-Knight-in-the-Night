using UnityEngine;

namespace LMA
{
    public class WeaponAttackData : ComponentData
    {
        [field: SerializeField] public AttackDamage[] AttackData { get; private set; }
    }
}