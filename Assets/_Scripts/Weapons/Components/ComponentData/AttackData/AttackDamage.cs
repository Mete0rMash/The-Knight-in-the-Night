using System;
using UnityEngine;

namespace LMA
{
    [Serializable]
    public class AttackDamage
    {
        [field: SerializeField] public float Amount { get; private set; }
        
        [field: SerializeField] public Vector2 Angle { get; private set; } 
        [field: SerializeField] public float Strength { get; private set; }
    }
}