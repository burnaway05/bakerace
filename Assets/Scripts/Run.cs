using UnityEngine;

namespace Core
{
    internal class Run : MonoBehaviour
    {
        [SerializeField] private GameObject _bikePrefab;
        [SerializeField] private GameObject _terrainPrefab;
        private Game _game;

        void Start()
        {
            _game = new Game();
            _game.Initialize();
        }

        void Update()
        {
            _game.Update();
        }
    }
}