using Gui;
using UnityEngine;
using Utils;
using Object = UnityEngine.Object;

namespace Core
{
    internal class Bike
    {
        private const float TimeToShowWheelie = 0.5f;
        private BikeView _view;
        private bool _isAccelerate;
        private bool _isBrake;
        private IStopwatch _wheelieStopwatch;
        private Settings _settings;
        private IBikeRaceGui _gui;

        public Bike(Settings settings, IBikeRaceGui gui)
        {
            _settings = settings;
            _gui = gui;
        }

        public void Initialize()
        {
            var obj = Object.Instantiate(_settings.BikePrefab, _settings.StartBikePosition, Quaternion.identity);
            _view = obj.GetComponent<BikeView>();
            _wheelieStopwatch = new Stopwatch();
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
            CheckForWheelie();
        }

        public void FixedUpdate()
        {
            AccelerateHandle();
            BrakeHandle();
        }

        private void AccelerateHandle()
        {
            if (_isAccelerate && !_isBrake && _view.IsBackTireOnGround())
            {
                var backWheelPhysics = _view.BackWheel.GetComponent<Rigidbody2D>();
                if (backWheelPhysics.angularVelocity > _settings.MaxBackTireTorque)
                {
                    backWheelPhysics.AddTorque(_settings.BackTireTorqueStep);
                }
            }
            else
            {
                _view.BackWheel.useMotor = false;
            }
        }

        private void BrakeHandle()
        {
            if (_isBrake && _view.IsBackTireOnGround())
            {
                _view.BackWheel.useMotor = false;
                _view.Body.drag += _settings.BrakeStep * Time.deltaTime;
            }
            else
            {
                _view.Body.drag = 0;
            }
        }

        private void CheckForWheelie()
        {
            if (_view.IsBackTireOnGround() && !_view.IsFrontTireOnGround())
            {
                if (!_wheelieStopwatch.IsStarted())
                {
                    _wheelieStopwatch.Start();
                }
                else if (_wheelieStopwatch.GetSeconds() > TimeToShowWheelie)
                {
                    _gui.ShowWheelie();
                }
            }
            else
            {
                _wheelieStopwatch.Stop();
            }
        }

        public void ResetState()
        {
            _view.gameObject.SetActive(false);

            _view.transform.position = _settings.StartBikePosition;
            _view.transform.rotation = Quaternion.identity;

            _view.BackWheel.transform.rotation = Quaternion.identity;
            _view.FrontWheel.transform.rotation = Quaternion.identity;

            _view.gameObject.SetActive(true);
        }
    }
}