namespace Assets.Scripts.Framework
{
    public abstract class MainGameObjectBehaviour : ESMonoBehaviour
    {
        protected virtual void OnEnable()
        {
            GameObjectManager.Instance.Add(this.gameObject);
        }

        protected virtual void OnDisable()
        {
            GameObjectManager.Instance.Remove(this.gameObject);
        }
    }
}
