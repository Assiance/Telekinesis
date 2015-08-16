using Assets.Scripts.MyGameScripts.Factories;
using Assets.Scripts.MyGameScripts.Services;
using UnityEngine;

namespace Assets.Scripts
{
    public class GameManager : MonoBehaviour
    {
        private InputService _inputService;
       
        private static GameManager _instance;

        private GameManager()
        {
        }

        public static GameManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameManager();
                }

                return _instance;
            }
        }

        protected void Awake()
        {
        }

        protected void Start()
        {
            _inputService = new InputService();
            var playerFactory = new CharacterFactory();

            playerFactory.CreatePlayer();
            playerFactory.CreateEnemy();
        }
        
        protected void Update()
        {
            MessagePump.Instance.Update(Time.fixedDeltaTime);

            _inputService.Update();
        }
    }
}
