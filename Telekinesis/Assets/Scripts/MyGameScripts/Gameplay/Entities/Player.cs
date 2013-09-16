using Assets.Scripts.MyGameScripts.Gameplay.Abilities;
using Assets.Scripts.MyGenericScripts.Framework.Components;
using Assets.Scripts.MyGenericScripts.Framework.Entities;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.MyGameScripts.Gameplay.Entities
{
    public class Player : SimpleEntity
    {
        #region Designer Variables
        public float MovementSpeed = 2.0f;
        public float WalkJump = 10f;
        public float Gravity = 20.0f;
        public float FallSpeed = 2.0f;
        public bool CanMove = true;
        #endregion

        [HideInInspector]
        public Telekinesis Telekenisis;

        private Vector3 _velocity;
        private CharacterController _characterController;

        public bool IsGrounded
        {
            get
            {
                return _characterController.isGrounded;
            }
        }

        [HideInInspector]
        public Vector3 Velocity
        {
            get { return _velocity; }
        }

        protected override void Start()
        {
            base.Start();

            Telekenisis = this.GetComponent<Telekinesis>();
            _characterController = this.GetComponent<CharacterController>();
        }

        public void Move(float inputAxis)
        {
            _velocity.x = inputAxis;
        }

        public void Jump(bool validInput)
        {
            if (validInput)
            {
                _velocity.y = WalkJump;
            }
        }

        public void ApplyFallSpeed()
        {
            _velocity.y -= FallSpeed;
        }

        public void ApplyGravity(float time)
        {
            _velocity.y -= Gravity * time;
        }

        public void ApplyMovement(float time)
        {
            _velocity.x *= MovementSpeed;
            _characterController.Move(_velocity * time);
        }

        //public IEnumerator EntitySelection<TAbility>(TAbility ability)
        //    where TAbility : Ability, ISelectionAbility
        //{

        //    var entities = ability.GetSelection<Crate>();

        //    yield return null;

        //    int elementPosition = entities.FindIndex(i => i.Highlighted == true);

        //    if (Input.GetButtonDown(KeyCode.O.ToString()))
        //    {
        //        entities[elementPosition].Highlighted = false;

        //        if (elementPosition == 0)
        //        {
        //            elementPosition = entities.Count - 1;
        //        }
        //        else
        //        {
        //            elementPosition -= 1;
        //        }

        //        entities[elementPosition].Highlighted = true;
        //    }

        //    if (Input.GetButtonDown(KeyCode.P.ToString()))
        //    {
        //        entities[elementPosition].Highlighted = false;

        //        if (elementPosition == entities.Count - 1)
        //        {
        //            elementPosition = 0;
        //        }
        //        else
        //        {
        //            elementPosition += 1;
        //        }

        //        entities[elementPosition].Highlighted = true;
        //    }

        //    entities.Find(i => i.Highlighted == true).CachedSprite.color = Color.blue;
        //}
   }
}
