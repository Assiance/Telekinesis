using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Framework;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class PickUp : ESMonoBehaviour
    {
        public bool CanPickUp = false;
        public bool IsHoldingWeapon = false;

        private Component _pickUpComponent;
        private Collider2D _other;

        protected void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad8) && CanPickUp && !IsHoldingWeapon)
            {
                this.gameObject.AddComponent(_pickUpComponent.GetType());
                Destroy(_other.gameObject);

                IsHoldingWeapon = true;
            }

            if (Input.GetKeyDown(KeyCode.D) && IsHoldingWeapon)
            {
                _pickUpComponent = GetComponent(typeof (Pickupable));
                Destroy(_pickUpComponent);

                IsHoldingWeapon = false;
                Instantiate(Resources.Load("Dagger"), CachedTransform.position, CachedTransform.rotation);
            }
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            var pickUpComponent = other.GetComponent(typeof (Pickupable));

            if (pickUpComponent != null)
            {
                _pickUpComponent = pickUpComponent;
                _other = other;
                CanPickUp = true;
            }
        }

        protected void OnTriggerExit2D(Collider2D other)
        {
            var pickUpComponent = other.GetComponent(typeof (Pickupable));

            if (pickUpComponent != null)
            {
                _pickUpComponent = null;
                _other = null;
                CanPickUp = false;
            }
        }
    }
}
