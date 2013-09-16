using Assets.Scripts.MyGenericScripts.Framework.Controllers;
using UnityEngine;

namespace Assets.Scripts.MyGameScripts.Gameplay.Entities
{
    public class PlayerController : Controller<Player>
    {
        protected override void Start()
        {
            base.Start();
        }

        private void Update()
        {
            if (Entity.IsGrounded)
            {
                if (Entity.CanMove)
                {
                    Entity.Move(Input.GetAxis("Horizontal"));
                    Entity.Jump(Input.GetButtonDown("Jump"));
                }

                Entity.Telekenisis.ToggleActive(Input.GetButtonDown("Fire1") && Entity.Velocity.x == 0);

                if (Entity.Telekenisis.IsActive)
                {
                    Entity.CanMove = false;

                    if (Entity.Telekenisis.Target == null)
                    {
                        //Entity.EntitySelection<Crate>(Entity.Telekenisis);
                    }

                    Entity.Telekenisis.InvokeAbility();
                }
                else
                {
                    Entity.CanMove = true;
                }
            }

            if (!Entity.IsGrounded)
            {
                if (Entity.CanMove)
                {
                    Entity.Move(Input.GetAxis("Horizontal"));

                    if (Input.GetButtonUp("Jump"))
                    {
                        Entity.ApplyFallSpeed();
                    }
                }
            }

            Entity.ApplyGravity(Time.fixedDeltaTime);
            Entity.ApplyMovement(Time.fixedDeltaTime);
        }
    }
}
