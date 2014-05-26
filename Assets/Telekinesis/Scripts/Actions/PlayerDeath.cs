using Assets.Scripts.Framework;
using Assets.Telekinesis.Scripts.Framework;

namespace Assets.Telekinesis.Scripts.Actions
{
    public class PlayerDeath : ESMonoBehaviour, IKillable
    {
        public void Kill()
        {
            renderer.enabled = false;
        }
    }
}
