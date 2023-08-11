using System.Diagnostics;
using UnityEngine;

namespace Core
{
    internal class Bike
    {
        private const int MaxBackTireTorque = -1500;
        private const float BackTireTorqueStep = -50f;
        private const int BrakeStep = 10;
        private BikeView _view;
        private bool _isAccelerate;
        private bool _isBrake;

        public void Initialize()
        {
            var settings = Run.Instance.Settings;
            var obj = Object.Instantiate(settings.BikePrefab, settings.StartBikePosition, Quaternion.identity);
            _view = obj.GetComponent<BikeView>();
        }

        public Vector3 GetPosition()
        {
            return _view.transform.position;
        }

        public void Accelerate()
        {
            _isAccelerate = true;
        }

        public void StopAccelerate()
        {
            _isAccelerate = false;
        }

        public void Brake()
        {
            _isBrake = true;
        }

        public void StopBrake()
        {
            _isBrake = false;
        }

        public void Update()
        {

        }

        public void FixedUpdate()
        {
            AccelerateHandle();
            BrakeHandle();
        }

        private void AccelerateHandle()
        {
            if (_isAccelerate && !_isBrake && _view.IsOnGround())
            {
                var backWheelPhysics = _view.BackWheel.GetComponent<Rigidbody2D>();

                if (backWheelPhysics.angularVelocity > MaxBackTireTorque)
                {
                    backWheelPhysics.AddTorque(BackTireTorqueStep);
                }
            }
            else
            {
                _view.BackWheel.useMotor = false;
            }
        }

        private void BrakeHandle()
        {
            if (_isBrake && _view.IsOnGround())
            {
                _view.BackWheel.useMotor = false;
                _view.Body.drag += BrakeStep * Time.deltaTime;
            }
            else
            {
                _view.Body.drag = 0;
            }
        }
    }
}