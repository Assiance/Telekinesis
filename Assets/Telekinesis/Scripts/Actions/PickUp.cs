using Assets.Scripts.Framework;
using Assets.Telekinesis.Scripts.Framework;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.Actions
{
    public class PickUp : ESMonoBehaviour
    {
        public bool CanPickUp = false;
        public bool IsHoldingWeapon = false;
        public KeyCode PickUpInput = KeyCode.P;
        public KeyCode DropInput = KeyCode.D;

        private Component _pickUpableComponent;
        private Collider2D _other;

        protected void OnEnable()
        {
            KeyboardEventManager.Instance.RegisterKeyDown(PickUpInput, PickUpItem);
            KeyboardEventManager.Instance.RegisterKeyDown(DropInput, DropItem);
        }

        public void PickUpItem(KeyCode key)
        {
            if (CanPickUp && !IsHoldingWeapon)
            {
                this.gameObject.AddComponent(_pickUpableComponent.GetType());
                Destroy(_other.gameObject);

                IsHoldingWeapon = true;
            }
        }

        public void DropItem(KeyCode key)
        {
            if (IsHoldingWeapon)
            {
                _pickUpableComponent = GetComponent(typeof(Pickupable));
                Destroy(_pickUpableComponent);

                IsHoldingWeapon = false;
                Instantiate(Resources.Load("Dagger"), CachedTransform.position, CachedTransform.rotation);
            }
        }

        protected void OnTriggerEnter2D(Collider2D other)
        {
            var pickUpableComponent = other.GetComponent(typeof (Pickupable));

            if (pickUpableComponent != null)
            {
                _pickUpableComponent = pickUpableComponent;
                _other = other;
                CanPickUp = true;
            }
        }

        protected void OnTriggerExit2D(Collider2D other)
        {
            var pickUpableComponent = other.GetComponent(typeof (Pickupable));

            if (pickUpableComponent != null)
            {
                _pickUpableComponent = null;
                _other = null;
                CanPickUp = false;
            }
        }
    }
}
