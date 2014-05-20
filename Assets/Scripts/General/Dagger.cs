using Assets.Scripts.Actions;
using UnityEngine;

namespace Assets.Scripts.General
{
    public class Dagger : Pickupable
    {
        public float AttackStrength = 10;

        //private Stats _statsComponent;

        //private void OnEnable()
        //{
        //    _statsComponent = GetComponent<Stats>();

        //    if (_statsComponent != null)
        //    {
        //        print(("KNIFE!!"));
        //        _statsComponent.AttackStrength += AttackStrength;
        //    }
        //}

        //private void OnDisable()
        //{
        //    if (_statsComponent != null)
        //    {
        //        _statsComponent.AttackStrength -= AttackStrength;
        //    }
        //}
    }
}

