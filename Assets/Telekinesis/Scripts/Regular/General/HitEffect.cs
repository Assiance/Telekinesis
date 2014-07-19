using Assets.Telekinesis.Scripts.Regular.Actions.Attacks;
using Assets.Telekinesis.Scripts.Regular.Framework;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.Regular.General
{
    public class HitEffect : ESMonoBehaviour, IHittable
    {
        public ParticleSystem Particle;

        public void Hit(IAttack hitter)
        {
            if (Particle != null)
                Particle.Play();
        }
    }
}
