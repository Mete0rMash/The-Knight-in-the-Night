using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LMA
{
    [Serializable]
    public class AttackSprites
    {
        [field: SerializeField] public Sprite[] Sprites { get; private set; }
    }
}
