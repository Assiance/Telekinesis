using Assets.Scripts.Framework;
using UnityEngine;

namespace Assets.Scripts.Actions
{
    public class Block : ESMonoBehaviour
    {
        public bool IsBlocking = false;

        protected void Update()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                IsBlocking = true;
            }
            else
            {
                IsBlocking = false;
            }
        }
    }
}
