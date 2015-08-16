using System;
using Assets.Scripts.MyGenericScripts.Framework.Controllers.States;

namespace Assets.Scripts
{
    public class ChangeStateArgs : EventArgs
    {
        public IState NewState { get; set; }
    }
}
