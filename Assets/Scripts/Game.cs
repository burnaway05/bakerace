﻿using System.Collections.Generic;
using System.Linq;
using Gui;
using UnityEngine;

namespace Core
{
    internal class Game : IBikeControl
    {
        private Bike _bike;
        private List<Terrain> _locations;
        private Camera _camera;
        private float _maxDistance;

        public Game(Camera camera)
        {
            _camera = camera;
        }

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
            if (Input.GetKeyDown(KeyCode.RightArrow))
                Accelerate();
            if (Input.GetKeyUp(KeyCode.RightArrow))
                StopAccelerate();
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                Brake();
            if (Input.GetKeyUp(KeyCode.LeftArrow))
                StopBrake();

            MoveCamera();
            CheckMaxDistance();
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

        public void MoveCamera()
        {
            Vector3 end = Vector3.MoveTowards(_camera.transform.position, _bike.GetPosition(), Run.Instance.Settings.CameraSpeed * Time.deltaTime);
            end.z = _camera.transform.position.z;
            _camera.transform.position = end;
        }

        public void CheckMaxDistance()
        {
            var passedDistance = _bike.GetPosition().x - Run.Instance.Settings.StartBikePosition.x;
            if (passedDistance > _maxDistance)
            {
                _maxDistance = passedDistance;
                Run.Instance.Gui.UpdateDistance(_maxDistance);
            }
        }

        public void Restart()
        {
            _bike.ResetState();
            _maxDistance = 0;
        }
    }
}