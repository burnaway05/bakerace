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

        public Game Game => _game;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            _gui = FindObjectOfType<Gui.Gui>();
            _game = new Game(_settings, _gui, _camera);

            _gui.Initialize(_game);
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