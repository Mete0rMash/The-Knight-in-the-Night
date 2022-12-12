using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LMA.Weapons
{
    [CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Basic Weapon Data", order = 0)]
    public class WeaponData_SO : ScriptableObject
    {
        [field: SerializeField] public int NumberOfAttacks { get; private set; }

        [field: SerializeReference] public List<ComponentData> componentData { get; private set; }

        public T GetData<T>()
        {
            return componentData.OfType<T>().FirstOrDefault();
        }

        [ContextMenu("Add Sprite Data")]
        private void AddSpriteData() => componentData.Add(new WeaponSpriteData());
    }
}
