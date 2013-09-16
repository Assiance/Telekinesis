using UnityEngine;

namespace Assets.Scripts.MyGenericScripts.Framework.Entities
{
    public abstract class Entity : MyMonoBehaviour
    {
        public Transform CachedTransform { get; set; }
        public Renderer CachedRenderer { get; set; }
        public Collider CachedCollider { get; set; }
        public tk2dSprite CachedSprite { get; set; }
        
        protected virtual void Awake()
        {
            CachedTransform = gameObject.transform != null ? gameObject.transform : null;
            CachedRenderer = gameObject.renderer != null ? gameObject.renderer : null;
            CachedCollider = gameObject.collider != null ? gameObject.collider : null;
        }

        protected virtual void Start()
        {
            CachedSprite = this.GetComponent<tk2dSprite>();  
        }
    }
}
