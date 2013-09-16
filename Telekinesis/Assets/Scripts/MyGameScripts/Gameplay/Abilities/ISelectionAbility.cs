using Assets.Scripts.MyGameScripts.Gameplay.Entities.Interfaces;
using Assets.Scripts.MyGenericScripts.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.MyGameScripts.Gameplay.Abilities
{
    interface ISelectionAbility
    {
        List<TEntity> GetSelection<TEntity>() where TEntity : Entity, ISelectable;
    }
}
