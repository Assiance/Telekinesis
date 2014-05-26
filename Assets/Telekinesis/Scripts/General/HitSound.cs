using Assets.Telekinesis.Scripts.Actions.Attacks;
using Assets.Telekinesis.Scripts.Framework;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.General
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
