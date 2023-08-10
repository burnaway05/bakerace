using UnityEngine;

namespace Core
{
    internal class Run : MonoBehaviour
    {
        public static Run Instance;

        [SerializeField] private Settings _settings;
        private Game _game;

        public Settings Settings => _settings;

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
    }
}