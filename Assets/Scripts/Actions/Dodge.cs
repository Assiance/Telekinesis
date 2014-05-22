using Assets.Scripts.Framework;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class Dodge : ESMonoBehaviour
    {
        public float DodgeDistance = 3;
        public KeyCode DodgeInput = KeyCode.Space;

        private bool _shouldDodge = false;

        protected void OnEnable()
        {
            KeyboardEventManager.Instance.RegisterKeyDown(DodgeInput, DoDodge);
            KeyboardEventManager.Instance.RegisterKeyUp(DodgeInput, UnDodge);
        }

        // Update is called once per frame
        protected void FixedUpdate()
        {
            if (_shouldDodge)
            {
                ShouldDodge();
            }
        }

        private void ShouldDodge()
        {
                var angle = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * Mathf.Rad2Deg;
                CachedTransform.Translate(Mathf.Cos(angle * Mathf.Deg2Rad) * DodgeDistance,
                                          Mathf.Sin(angle * Mathf.Deg2Rad) * DodgeDistance, 0);
        }

        public void DoDodge(KeyCode key)
        {
            _shouldDodge = true;
        }

        public void UnDodge(KeyCode key)
        {
            _shouldDodge = false;
        }
    }
}
