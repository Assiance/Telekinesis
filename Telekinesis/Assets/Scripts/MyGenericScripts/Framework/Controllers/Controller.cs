using Assets.Scripts.MyGenericScripts.Framework.Entities;

namespace Assets.Scripts.MyGenericScripts.Framework.Controllers
{
    public abstract class Controller<TEntity> : MyMonoBehaviour
        where TEntity : Entity
    {
        protected TEntity Entity;

        protected virtual void Start()
        {
            Entity = this.GetComponent<TEntity>();  
        }
    }
}
