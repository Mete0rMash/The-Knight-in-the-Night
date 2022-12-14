using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LMA.Weapons.Components
{
    public class WeaponAttack : WeaponComponent
    {
        private List<IDamageable> detectedDamageables = new List<IDamageable>();
        private List<IKnockbackable> detectedKnockbackables = new List<IKnockbackable>();

        private CoreSystem.Movement Movement
        {
            get => movement ?? Core.GetCoreComponent(ref movement);
        }
        
        private CoreSystem.Movement movement;
        
        private WeaponAttackData data;


        private void HandleAttack()
        {
            var currentAttackData = data.AttackData[weapon.CurrentAttackCounter];

            foreach (IDamageable item in detectedDamageables.ToList())
            {
                item.Damage(currentAttackData.Amount);
            }

            foreach (IKnockbackable item in detectedKnockbackables.ToList())
            {
                item.Knockback(currentAttackData.Angle, currentAttackData.Strength, Movement.FacingDirection);
            }
        }
        
        protected override void Awake()
        {
            base.Awake();

            data = weapon.Data.GetData<WeaponAttackData>();
        }
        
        public void AddToDetected(Collider2D collision)
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();

            if (damageable != null)
            {
                detectedDamageables.Add(damageable);
            }

            IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

            if (knockbackable != null)
            {
                detectedKnockbackables.Add(knockbackable);
            }
        }
        
        public void RemoveFromDetected(Collider2D collision)
        {
            IDamageable damageable = collision.GetComponent<IDamageable>();

            if (damageable != null)
            {
                detectedDamageables.Remove(damageable);
            }
            
            IKnockbackable knockbackable = collision.GetComponent<IKnockbackable>();

            if (knockbackable != null)
            {
                detectedKnockbackables.Remove(knockbackable);
            }
        }
        
        protected override void OnEnable()
        {
            base.OnEnable();

            eventHandler.OnAction += HandleAttack;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            
            eventHandler.OnAction -= HandleAttack;
        }
    }
}