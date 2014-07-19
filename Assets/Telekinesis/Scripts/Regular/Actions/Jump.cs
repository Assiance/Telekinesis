using Assets.Telekinesis.Scripts.Regular.Framework;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.Regular.Actions
{
    public class Jump : ESMonoBehaviour
    {
        public KeyCode JumpInput = KeyCode.Space;
        public Vector2 JumpForce = new Vector2(0, 300f);
        public Transform GroundCheck;
        public float GroundCheckRadius = 0.2f;
        public bool IsGrounded;
        public LayerMask WhatIsGround;

        protected void OnEnable()
        {
            KeyboardEventManager.Instance.RegisterKeyDown(JumpInput, DoJump);
        }
        
        protected void FixedUpdate()
        {
            IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundCheckRadius, WhatIsGround);
        }

        public void DoJump(KeyCode key)
        {
            if (IsGrounded)
            {
                rigidbody2D.AddForce(JumpForce);
            }
        }
    }
}
