using Assets.Telekinesis.Scripts.Regular.Framework;

namespace Assets.Telekinesis.Scripts.Regular.Actions
{
    public class PlayerDeath : ESMonoBehaviour, IKillable
    {
        public void Kill()
        {
            renderer.enabled = false;
        }
    }
}
