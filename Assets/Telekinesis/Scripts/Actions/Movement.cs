using Assets.Scripts.Framework;
using Assets.Telekinesis.Scripts.Framework;
using Assets.Telekinesis.Scripts.UI;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.Actions
{
    public class Movement : ESMonoBehaviour
    {
        public float WalkSpeed = 1f;
        public float RunSpeed = 5f;
        public float MaxVelocityChange = 10.0f;

        public Direction FacingDirection = Direction.Right;
        public Sprite RightFacingSprite;
        public Sprite LeftFacingSprite;
        public Sprite UpFacingSprite;
        public Sprite DownFacingSprite;

        public bool ShouldUseStatsComponent;
        public bool HasVericalMovement;
        public bool HasRigidBody;

        private Vector2 _moveDelta;
        private Vector2 _velocityDelta;
        //private Stats _stats;

        public enum Direction
        {
            Right,
            Left,
            Up,
            Down
        };

        protected void OnEnable()
        {
            _moveDelta = new Vector2();
            HasRigidBody = GetComponent<Rigidbody2D>() != null;
        }

        protected void Update()
        {
            //todo: Remove string hardcode
            SetMoveDelta(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }

        protected void FixedUpdate()
        {
            Move();
        }

        protected void Move()
        {
            //todo: code for AI and Player
            SetVelocityDelta();
            FaceCorrectDirection();
            ApplyVelocity();
        }

        private void ApplyVelocity()
        {
            if (HasRigidBody)
            {
                transform.rigidbody2D.velocity += new Vector2(_velocityDelta.x, 0);

                if (HasVericalMovement)
                    transform.rigidbody2D.velocity += new Vector2(0, _velocityDelta.y);
            }
            else
            {
                CachedTransform.Translate(_velocityDelta.x * GridOverlay.CellPerSecondSpeed, _velocityDelta.y * GridOverlay.CellPerSecondSpeed, 0);
            }
        }

        public void SetMoveDelta(float horizontalInput, float verticalInput)
        {
            _moveDelta.x = horizontalInput;
            _moveDelta.y = (HasVericalMovement) ? verticalInput : 0f;
        }

        private void SetVelocityDelta()
        {
            var targetVelocity = (Input.GetButton("Run")) ? _moveDelta * RunSpeed : _moveDelta * WalkSpeed;

            if (HasRigidBody)
            {
                _velocityDelta = (targetVelocity - CachedTransform.rigidbody2D.velocity);
                _velocityDelta.x = Mathf.Clamp(_velocityDelta.x, -MaxVelocityChange, MaxVelocityChange);
                _velocityDelta.y = Mathf.Clamp(_velocityDelta.y, -MaxVelocityChange, MaxVelocityChange);
            }
            else
            {
                _velocityDelta = targetVelocity;
            }
        }

        private void FaceCorrectDirection()
        {
            var movingHorizontally = Mathf.Abs(_moveDelta.x) >= Mathf.Abs(_moveDelta.y);
            if (movingHorizontally)
            {
                FaceHorizontalDirection();
            }
            else
            {
                FaceVerticalDirection();
            }
        }

        private void FaceHorizontalDirection()
        {
            if (_moveDelta.x >= 0)
            {
                //face right  
                FacingDirection = Direction.Right;
                //GetComponent<SpriteRenderer>().sprite = RightFacingSprite;
            }
            else
            {
                //face left
                FacingDirection = Direction.Left;
                //GetComponent<SpriteRenderer>().sprite = LeftFacingSprite;
            }
        }

        private void FaceVerticalDirection()
        {
            if (_moveDelta.y > 0)
            {
                //face up
                FacingDirection = Direction.Up;
                // GetComponent<SpriteRenderer>().sprite = UpFacingSprite;
            }
            else
            {
                //face down
                FacingDirection = Direction.Down;
                //  GetComponent<SpriteRenderer>().sprite = DownFacingSprite;
            }
        }
    }
}