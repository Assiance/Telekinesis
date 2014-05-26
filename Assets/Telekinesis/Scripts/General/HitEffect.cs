using Assets.Telekinesis.Scripts.Actions.Attacks;
using Assets.Telekinesis.Scripts.Framework;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.General
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
