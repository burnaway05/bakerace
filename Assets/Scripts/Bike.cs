using UnityEngine;

namespace Core
{
    internal class Bike
    {
        private GameObject _view;

        public Bike()
        {

        }

        public void Initialize()
        {
            var settings = Run.Instance.Settings;
            _view = Object.Instantiate(settings.BikePrefab);
        }

        public void Accelerate()
        {

        }

        public void Decelerate()
        {

        }

        public void Update()
        {

        }
    }
}
