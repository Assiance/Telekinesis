using Assets.Scripts.Actions;
using Assets.Scripts.Framework;

namespace Assets.Scripts.Actions
{
    public class PlayerDeath : ESMonoBehaviour, IKillable
    {
        public void Kill()
        {
            renderer.enabled = false;
        }
    }
}
