using UnityEngine;

namespace Core
{
    internal class Bike
    {
        private BikeView _view;

        public void Initialize()
        {
            var settings = Run.Instance.Settings;
            var obj = Object.Instantiate(settings.BikePrefab, settings.StartBikePosition, Quaternion.identity);
            _view = obj.GetComponent<BikeView>();
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