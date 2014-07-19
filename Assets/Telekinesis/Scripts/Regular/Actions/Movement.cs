using Assets.Telekinesis.Scripts.Regular.Framework;
using Assets.Telekinesis.Scripts.Regular.UI;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.Regular.Actions
{
    public class Movement : ESMonoBehaviour
    {
        public float WalkSpeed = 1f;
        public float RunSpeed = 5f;
        public float MaxVelocityChange = 10.0f;
        public float MinVelocityChange = -10.0f;

        //public FaceDirection FacingDirection = FaceDirection.Right;
        //public Sprite RightFacingSprite;
        //public Sprite LeftFacingSprite;
        //public Sprite UpFacingSprite;
        //public Sprite DownFacingSprite;

        public bool HasVericalMovement;
        public bool HasRigidBody;

        private Vector2 _targetVelocity;

        public enum FaceDirection
        {
            Right,
            Left,
            Up,
            Down
        };

        protected void OnEnable()
        {
            _targetVelocity = new Vector2();
            HasRigidBody = GetComponent<Rigidbody2D>() != null;
        }

        protected void Update()
        {
            //todo: Remove string hardcode
            //todo: code for AI and Human
            var moveDelta = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            _targetVelocity = GetTargetVelocity(moveDelta, Input.GetButton("Run"));
        }

        protected void FixedUpdate()
        {
            Move(_targetVelocity);
        }

        public void Move(Vector2 targetVelocity)
        {
            if (HasVericalMovement == false)
                targetVelocity.y = 0;

            var velocity = GetVelocity(targetVelocity);
            //FacingDirection = GetFacingDirection(_moveDelta);
            //GetComponent<SpriteRenderer>().sprite = FacingDirection;
            ApplyVelocity(velocity);
        }

        private Vector2 GetTargetVelocity(Vector2 moveDelta, bool isRunning)
        {
            return (isRunning) ? moveDelta * RunSpeed : moveDelta * WalkSpeed;
        }

        private Vector2 GetVelocity(Vector2 targetVelocity)
        {
            var velocity = new Vector2();

            if (HasRigidBody)
            {
                velocity = (targetVelocity - CachedTransform.rigidbody2D.velocity);
                velocity.x = Mathf.Clamp(velocity.x, MinVelocityChange, MaxVelocityChange);
                velocity.y = Mathf.Clamp(velocity.y, MinVelocityChange, MaxVelocityChange);
            }
            else
            {
                velocity = targetVelocity;// *GridOverlay.CellPerSecondSpeed;
            }

            return velocity;
        }

        private void ApplyVelocity(Vector2 velocity)
        {
            if (HasRigidBody)
            {
                transform.rigidbody2D.velocity += new Vector2(velocity.x, 0);

                if (HasVericalMovement)
                {
                    transform.rigidbody2D.velocity += new Vector2(0, velocity.y);
                }
            }
            else
            {
                CachedTransform.Translate(velocity, 0);
            }
        }

        private FaceDirection GetFacingDirection(Vector2 moveDelta)
        {
            FaceDirection faceDirection;

            var movingHorizontally = Mathf.Abs(moveDelta.x) >= Mathf.Abs(moveDelta.y);
            if (movingHorizontally)
            {
                faceDirection = FaceHorizontalDirection(moveDelta);
            }
            else
            {
                faceDirection = FaceVerticalDirection(moveDelta);
            }

            return faceDirection;
        }

        private FaceDirection FaceHorizontalDirection(Vector2 moveDelta)
        {
            if (moveDelta.x >= 0)
            {
                //face right  
                return FaceDirection.Right;
                //GetComponent<SpriteRenderer>().sprite = RightFacingSprite;
            }
            else
            {
                //face left
                return FaceDirection.Left;
                //GetComponent<SpriteRenderer>().sprite = LeftFacingSprite;
            }
        }

        private FaceDirection FaceVerticalDirection(Vector2 moveDelta)
        {
            if (moveDelta.y > 0)
            {
                //face up
                return FaceDirection.Up;
                // GetComponent<SpriteRenderer>().sprite = UpFacingSprite;
            }
            else
            {
                //face down
                return FaceDirection.Down;
                //  GetComponent<SpriteRenderer>().sprite = DownFacingSprite;
            }
        }
    }
}