using Gui;
using UnityEngine;

namespace Core
{
    internal class Run : MonoBehaviour
    {
        public static Run Instance;

        [SerializeField] private Settings _settings;
        [SerializeField] private Camera _camera;
        [SerializeField] private IBikeRaceGui _gui;
        private Game _game;

        public Settings Settings => _settings;
        public Game Game => _game;
        public IBikeRaceGui Gui => _gui;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _game = new Game(_camera);
            _game.Initialize();

            _gui = FindObjectOfType<Gui.Gui>();
            _gui.Initialize(_game);
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