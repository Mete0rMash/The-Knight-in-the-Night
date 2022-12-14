using UnityEngine;

namespace LMA.CoreSystem
{
    public class Death : CoreComponent
    {
        [SerializeField] private GameObject[] deathParticles;
        [SerializeField] private GameObject Fin;

        private ParticleManager ParticleManager => particleManager ? particleManager : core.GetCoreComponent(ref particleManager);

        private ParticleManager particleManager;

        private Stats Stats => stats ? stats : core.GetCoreComponent(ref stats);
        private Stats stats;

        public void Die()
        {
            foreach(var particle in deathParticles)
            {
                ParticleManager.StartParticles(particle);
            }

            if (gameObject.CompareTag("Boss"))
            {
                Fin.SetActive(true);
            }

            core.transform.parent.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            Stats.OnHealthZero += Die;
        }

        private void OnDisable()
        {
            Stats.OnHealthZero -= Die;
        }
    }
}
