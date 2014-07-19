using Assets.Telekinesis.Scripts.Regular.Framework;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.Regular.Actions
{
    public class Lift : ESMonoBehaviour
    {
        public KeyCode LiftInput = KeyCode.LeftControl;
        public float HorizontalPush = 100f;
        public float VerticalPush = 100f;
        public bool LiftActivated = false;

        private Movement _movementComponent;
        public Transform _selectedObject = null;

        protected void OnEnable()
        {
            KeyboardEventManager.Instance.RegisterKeyHeldDown(KeyCode.LeftControl, DoLift);
            KeyboardEventManager.Instance.RegisterKeyUp(KeyCode.LeftControl, UnLift);

            _movementComponent = GetComponent<Movement>();
        }

        protected void Update()
        {
            if (LiftActivated)
            {
                ShouldLift();
            }
        }

        private void ShouldLift()
        {
            if (_selectedObject != null)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow))
                    _selectedObject.rigidbody2D.AddForce(new Vector2(0, VerticalPush));

                if (Input.GetKeyDown(KeyCode.DownArrow))
                    _selectedObject.rigidbody2D.AddForce(new Vector2(0, -VerticalPush));

                if (Input.GetKeyDown(KeyCode.RightArrow))
                    _selectedObject.rigidbody2D.AddForce(new Vector2(HorizontalPush, 0));

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                    _selectedObject.rigidbody2D.AddForce(new Vector2(-HorizontalPush, 0));
            }
        }

        public void DoLift(KeyCode key)
        {
            if (_movementComponent.enabled)
                _movementComponent.enabled = false;

            LiftActivated = true;

            if (Input.GetMouseButtonDown(0) && _selectedObject == null)
            {
                var ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _selectedObject = Physics2D.Raycast(new Vector2(ray.x, ray.y), Vector2.zero, 10).transform;
            }
        }

        public void UnLift(KeyCode key)
        {
            _movementComponent.enabled = true;
            _selectedObject = null;

            LiftActivated = false;
        }
    }
}
