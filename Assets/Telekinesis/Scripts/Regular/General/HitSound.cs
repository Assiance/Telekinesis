using Assets.Telekinesis.Scripts.Regular.Actions.Attacks;
using Assets.Telekinesis.Scripts.Regular.Framework;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.Regular.General
{
    [RequireComponent(typeof (AudioSource))]
    public class HitSound : ESMonoBehaviour, IHittable
    {
        public AudioClip Clip;

        public void Hit(IAttack hitter)
        {
            audio.PlayOneShot(Clip);
        }
    }
}
