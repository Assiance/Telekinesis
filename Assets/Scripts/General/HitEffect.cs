using Assets.Scripts.Actions.Attacks;
using Assets.Scripts.Framework;
using UnityEngine;

namespace Assets.Scripts.General
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
