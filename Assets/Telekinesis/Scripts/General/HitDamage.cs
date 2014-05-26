using System;
using Assets.Telekinesis.Scripts.Actions;
using Assets.Telekinesis.Scripts.Actions.Attacks;
using Assets.Telekinesis.Scripts.Framework;
using Assets.Telekinesis.Scripts.UI;

namespace Assets.Telekinesis.Scripts.General
{
    public class HitDamage : ESMonoBehaviour, IHittable
    {
        public Action HasDied;
        public Action HasTakenDamage;

        private IKillable _killableComponent;
        private HealthBar _healthComponent;

        protected void OnEnable()
        {
            _killableComponent = GetComponent(typeof (IKillable)) as IKillable;
            _healthComponent = GetComponent(typeof(HealthBar)) as HealthBar;
        }

        public void Hit(IAttack hitter)
        {
            _healthComponent.TakeDamage(hitter.Damage());

            if (HasTakenDamage != null)
                HasTakenDamage.Invoke();

            if (_healthComponent.CurrentHealth <= 0)
            {
                _killableComponent.Kill();

                if (HasDied != null)
                    HasDied.Invoke();
            }
        }
    }
}
