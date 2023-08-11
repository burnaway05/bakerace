using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Core
{
    internal class Game
    {
        private Bike _bike;
        private List<Terrain> _locations;

        public void Initialize()
        {
            _bike = new Bike();
            _bike.Initialize();

            _locations = new List<Terrain>(2);

            var terrain = new Terrain(Run.Instance.Settings.StartTerrainPosition);
            _locations.Add(terrain);
            SpawnTerrain();
        }

        public void Update()
        {
            _bike.Update();
        }


        public void FixedUpdate()
        {
            _bike.FixedUpdate();
        }

        public void SpawnTerrain()
        {
            if (_locations.Count > 0)
            {
                var lastTerrain = _locations.Last();
                var terrain = new Terrain(lastTerrain.GetRightBottomPosition());
                terrain.DeformMesh(lastTerrain.GetRightTopVertex());
                lastTerrain.DisableEnterTrigger();
                _locations.Add(terrain);
            }
        }

        public void Accelerate()
        {
            _bike.Accelerate();
        }

        public void StopAccelerate()
        {
            _bike.StopAccelerate();
        }

        public void Brake()
        {
            _bike.Brake();
        }

        public void StopBrake()
        {
            _bike.StopBrake();
        }
    }
}
