using System;
using LMA.Weapons.Components;
using UnityEngine;

namespace LMA.Weapons
{
    public class WeaponHitboxToWeapon : MonoBehaviour
    {
        private WeaponAttack weapon;

        private void Awake()
        {
            weapon = GetComponentInParent<WeaponAttack>();
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("OnTriggerEnter2D");
            weapon.AddToDetected(col);
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            Debug.Log("OnTriggerExit2D");
            weapon.RemoveFromDetected(col);
        }
    }
}