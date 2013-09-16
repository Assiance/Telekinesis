using UnityEngine;

namespace Assets.Scripts.MyGenericScripts.Framework.Entities
{
    public abstract class PhysicsEntity : Entity
    {
        public Rigidbody CachedRigidbody { get; set; }

        protected override void Awake()
        {
            CachedRigidbody = gameObject.rigidbody != null ? gameObject.rigidbody : null;
        }
    }
}
