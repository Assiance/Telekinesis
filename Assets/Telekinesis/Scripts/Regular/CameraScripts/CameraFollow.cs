using Assets.Telekinesis.Scripts.Regular.Framework;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.Regular.CameraScripts
{
    public class CameraFollow : ESMonoBehaviour
    {
        public GameObject Target;

        protected void LateUpdate()
        {
            transform.position = new Vector3(Target.transform.position.x, Target.transform.position.y,
                                             transform.position.z);
        }
    }
}

