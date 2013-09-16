using Assets.Scripts.MyGameScripts.Gameplay.Entities.Interfaces;
using Assets.Scripts.MyGenericScripts.Framework.Entities;

namespace Assets.Scripts.MyGameScripts.Gameplay.Entities
{
    public class Crate : PhysicsEntity, ISelectable, ILiftableEntity
    {
        public bool Selected { get; set; }
        public bool Highlighted { get; set; }
    }
}
