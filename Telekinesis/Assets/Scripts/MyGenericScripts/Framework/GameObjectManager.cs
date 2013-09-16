using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Assets.Scripts.MyGameScripts.Gameplay.Entities.Interfaces;
using Assets.Scripts.MyGenericScripts.Framework.Entities;

namespace Assets.Scripts.MyGenericScripts.Framework
{
    public class GameObjectManager : MyMonoBehaviour
    {
        private static GameObjectManager _instance;
        private static IList<GameObject> _gameObjects;
        private static IList<GameObject> _entityGameObjects;

        private GameObjectManager()
        {
        }

        public static GameObjectManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameObjectManager();
                }

                return _instance;
            }
        }
        
        protected void Awake()
        {
            _gameObjects = new List<GameObject>();
            _entityGameObjects = new List<GameObject>();
        }

        protected void Start()
        {
            _gameObjects = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];
            _entityGameObjects = _gameObjects.Where(i => i.GetComponent<Entity>() != null).ToList();
        }

        private List<TLiftable> GetLiftableObjects<TLiftable>()
            where TLiftable : Entity, ILiftableEntity
        {
            var liftableEntities = (from e in GameObject.FindObjectsOfType(typeof(ILiftableEntity))
                                    select e as TLiftable).ToList();

            return liftableEntities;
        }

        public static List<T> GetGameObjectsThatImplement<T>()
            where T : class
        {
            var targetObjects = (from item in _entityGameObjects
                                 where typeof(T).IsAssignableFrom(item.GetType())
                                 select item).ToList();

            var to = targetObjects.Count();

            return new List<T>();
        }
    }
}
