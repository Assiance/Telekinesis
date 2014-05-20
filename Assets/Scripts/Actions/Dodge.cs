using Assets.Scripts.Framework;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class Dodge : ESMonoBehaviour
    {
        public float DodgeDistance = 3;
        //private Stats _stats;

        private void OnEnable()
        {
        }

        // Update is called once per frame
        protected void FixedUpdate()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                var angle = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * Mathf.Rad2Deg;
                CachedTransform.Translate(Mathf.Cos(angle * Mathf.Deg2Rad) * DodgeDistance,
                                          Mathf.Sin(angle * Mathf.Deg2Rad) * DodgeDistance, 0);
            }
        }
    }
}
