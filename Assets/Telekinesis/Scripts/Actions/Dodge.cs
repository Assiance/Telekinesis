using Assets.Scripts.Framework;
using Assets.Telekinesis.Scripts.Framework;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.Actions
{
    public class Dodge : ESMonoBehaviour
    {
        public float DodgeDistance = 3;
        public KeyCode DodgeInput = KeyCode.Space;

        private bool _shouldDodge = false;

        protected void OnEnable()
        {
            KeyboardEventManager.Instance.RegisterKeyDown(DodgeInput, DoDodge);
        }

        public void DoDodge(KeyCode key)
        {
            var angle = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * Mathf.Rad2Deg;
            CachedTransform.Translate(Mathf.Cos(angle * Mathf.Deg2Rad) * DodgeDistance,
                                      Mathf.Sin(angle * Mathf.Deg2Rad) * DodgeDistance, 0);
        }
    }
}
