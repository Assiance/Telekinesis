using Assets.Scripts.Framework;

namespace Assets.Telekinesis.Scripts.Framework
{
    public class TrackableObject : ESMonoBehaviour
    {
        protected virtual void OnEnable()
        {
            SpriteManager.Instance.Add(this.gameObject);
        }

        protected virtual void OnDisable()
        {
            SpriteManager.Instance.Remove(this.gameObject);
        }
    }
}
