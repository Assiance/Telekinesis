using Assets.Telekinesis.Scripts.Regular.Framework;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.Regular.Actions
{
    public class Block : ESMonoBehaviour
    {
        public bool IsBlocking = false;
        public KeyCode BlockInput = KeyCode.LeftShift;

        protected void OnEnable()
        {
            KeyboardEventManager.Instance.RegisterKeyDown(BlockInput, DoBlock);
            KeyboardEventManager.Instance.RegisterKeyUp(BlockInput, UnBlock);
        }

        protected void Update()
        {
        }

        public void DoBlock(KeyCode key)
        {
            IsBlocking = true;
        }

        public void UnBlock(KeyCode key)
        {
            IsBlocking = false;
        }
    }
}
