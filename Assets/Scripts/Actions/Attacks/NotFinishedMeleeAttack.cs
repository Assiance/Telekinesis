using System.Collections.Generic;
using Assets.Scripts.Framework;
using Assets.Scripts.General;
using UnityEngine;

namespace Assets.Scripts.Actions.Attacks
{
    public class NotFinishedMeleeAttack : ESMonoBehaviour, IAttack
    {
        public float AttackStrength = 10f;
        public AudioClip MeleeClip;
      
        //private Stats _stats;
        private List<Collider2D> _objectsInAttackRange;

        protected void OnEnable()
        {
            _objectsInAttackRange = new List<Collider2D>();
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Keypad1))
            {
                OnAttack();
            }
        }

        protected void OnAttack()
        {
            // var e = Physics2D.OverlapArea(new Vector2(transform.position.x + .5f, transform.position.y + .5f), new Vector2(transform.position.x + 1.5f, transform.position.y + -0.5f));
            print("attack");

            List<Tuple<Vector2, Vector2>> grid = new List<Tuple<Vector2, Vector2>>();
            grid.Add(new Tuple<Vector2, Vector2>(new Vector2(CachedTransform.position.x, CachedTransform.position.y),
                                                 new Vector2(CachedTransform.position.x + 1f,
                                                             CachedTransform.position.y + 1f)));
            //_objectsInAttackRange = IntersectAttackGrid(grid, Movement.Direction.Right);

            if (MeleeClip != null)
                audio.PlayOneShot(MeleeClip);

            foreach (var attackableObjects in _objectsInAttackRange)
            {
                var blockComponent = attackableObjects.GetComponent<Block>();

                var takeDamage = true;
                if (blockComponent != null)
                {
                    if (blockComponent.IsBlocking)
                    {
                        takeDamage = false;
                    }
                }

                if (takeDamage)
                {
                    var hitComponents = attackableObjects.GetComponents(typeof (IHittable));

                    if (hitComponents == null)
                        return;

                    foreach (var hitComponent in hitComponents)
                    {
                        ((IHittable) hitComponent).Hit(this);
                    }
                }
            }
        }

        public float Damage()
        {
            return AttackStrength;
        }
    }
}