using Assets.Scripts.MyGenericScripts.Framework.Entities;

namespace Assets.Scripts.MyGenericScripts.Framework.Components
{
    public abstract class Ability : Component
    {
        public bool IsActive { get; set; }
        public abstract Entity Target { get; set; }

        protected Entity Self { get; set; }

        protected virtual void Start()
        {
            IsActive = false;
            Self = this.GetComponent<Entity>();
        }

        protected abstract void Invoke();
        
        public void InvokeAbility()
        {
            if (IsActive)
            {
                if (Target != null)
                {
                    Invoke();
                }
            }
        }

        public void ToggleActive()
        {
            IsActive = (IsActive == false) ? true : false;
        }

        public void ToggleActive(bool validInput)
        {
            if (validInput)
            {
                IsActive = (IsActive == false) ? true : false;
            }
        }
    }
}
