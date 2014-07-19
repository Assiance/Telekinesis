using UnityEngine;

namespace Assets.Telekinesis.Scripts.Regular.Framework
{
    public abstract class ESMonoBehaviour : MonoBehaviour
    {
        private Transform _cachedTransform;

        protected Transform CachedTransform
        {
            get
            {
                if (_cachedTransform == null)
                    _cachedTransform = GetComponent<Transform>();

                return _cachedTransform;
            }
        }
    }
}

