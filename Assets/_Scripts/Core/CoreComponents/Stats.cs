using System;
using UnityEngine;
using UnityEngine.UI;

namespace LMA.CoreSystem
{
    public class Stats : CoreComponent
    {
        [SerializeField] private Slider hpSlider;
        
        public event Action OnHealthZero;

        [SerializeField] private float maxHealth;
        private float currentHealth;

        protected override void Awake()
        {
            base.Awake();
            
            
            if (gameObject.layer.Equals("Player"))
            {
                LoadPlayerHealth();
            }

            hpSlider.maxValue = maxHealth;
            hpSlider.value = maxHealth;
            
            currentHealth = maxHealth;
        }

        public void DecreaseHealth(float amount)
        {
            currentHealth -= amount;
            
            if (currentHealth <= 0)
            {
                currentHealth = 0;

                OnHealthZero?.Invoke();

                Debug.Log("Health is zero!");
            }

            hpSlider.value = currentHealth;

            if (gameObject.layer.Equals("Player"))
            {
                SavePlayerHealth();
            }
        }

        public void IncreaseHealth(float amount)
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            
            hpSlider.value = currentHealth;
        }

        public void SavePlayerHealth()
        {
            PlayerPrefs.SetFloat("PlayerMaxHealth", maxHealth);
            PlayerPrefs.SetFloat("PlayerCurrentHealth", currentHealth);
        }
        
        private void LoadPlayerHealth()
        {
            maxHealth = PlayerPrefs.GetFloat("PlayerMaxHealth");
            currentHealth = PlayerPrefs.GetFloat("PlayerCurrentHealth");
        }
    }
}
