using Assets.Scripts.Framework;

namespace Assets.Scripts.General
{
    public class Stats : MainGameObjectBehaviour
    {
        public float MaxHealth = 100f;
        public float MaxEnergy = 100f;
        public float AttackStrength = 10f;
        public float ProjectileStrength = 10f;
        public float WalkSpeed = 1f;
        public float WalkForce = 100f;
        public float RunSpeed = 5f;
        public float RunForce = 500f;
        public float DodgeDistance = 1f;
        public float CurrentHealth { get; private set; }
        public float CurrentEnergy { get; private set; }

        private HealthBar _healthBar;
        private EnergyBar _energyBar;

        protected override void OnEnable()
        {
            base.OnEnable();

            _healthBar = GetComponent<HealthBar>();
            _energyBar = GetComponent<EnergyBar>();
            CurrentHealth = MaxHealth;
            CurrentEnergy = MaxEnergy;
        }
    }
}

