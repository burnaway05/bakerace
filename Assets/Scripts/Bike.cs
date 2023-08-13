using UnityEngine;
using Debug = System.Diagnostics.Debug;

namespace Core
{
    internal class Bike
    {
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
                if (backWheelPhysics.angularVelocity > Run.Instance.Settings.MaxBackTireTorque)
                {
                    backWheelPhysics.AddTorque(Run.Instance.Settings.BackTireTorqueStep);
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
                _view.Body.drag += Run.Instance.Settings.BrakeStep * Time.deltaTime;
            }
            else
            {
                _view.Body.drag = 0;
            }
        }

        public void ResetState()
        {
            _view.gameObject.SetActive(false);

            _view.transform.position = Run.Instance.Settings.StartBikePosition;
            _view.transform.rotation = Quaternion.identity;

            _view.BackWheel.transform.rotation = Quaternion.identity;
            _view.FrontWheel.transform.rotation = Quaternion.identity;

            _view.gameObject.SetActive(true);
        }
    }
}