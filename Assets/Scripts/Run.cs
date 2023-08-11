using UnityEngine;

namespace Core
{
    internal class Run : MonoBehaviour
    {
        public static Run Instance;

        [SerializeField] private Settings _settings;
        private Game _game;

        public Settings Settings => _settings;
        public Game Game => _game;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _game = new Game();
            _game.Initialize();
        }

        private void Update()
        {
            _game.Update();
        }

        private void FixedUpdate()
        {
            _game.FixedUpdate();
        }
    }
}