using Assets.Scripts.Actions.Attacks;
using Assets.Scripts.Framework;
using UnityEngine;

namespace Assets.Scripts.General
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
