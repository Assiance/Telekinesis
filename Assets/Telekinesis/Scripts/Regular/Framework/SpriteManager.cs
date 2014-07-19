using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Telekinesis.Scripts.Regular.Framework
{
    public class SpriteManager
    {
        private static SpriteManager _instance;
        private static IList<GameObject> _gameObjects;

        private SpriteManager()
        {
            _gameObjects = new List<GameObject>();
        }

        public static SpriteManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SpriteManager();
                }

                return _instance;
            }
        }

        public void Add(GameObject theGameObject)
        {
            _gameObjects.Add(theGameObject);
        }

        public void Remove(GameObject theGameObject)
        {
            _gameObjects.Remove(theGameObject);
        }

        public static List<GameObject> GetGameObjectsThatImplement<T>()
            where T : class
        {
            var targetObjects = (from item in _gameObjects
                                 where item is T
                                 select item);

            return targetObjects.ToList();
        }
    }
}
