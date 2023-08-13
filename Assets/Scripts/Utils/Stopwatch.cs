using System;

namespace Utils
{
    public interface IStopwatch
    {
        void Start();
        void Stop();
        bool IsStarted();
        float GetSeconds();
    }

    public class Stopwatch : IStopwatch
    {
        private DateTime _wheelieTimer;

        public void Start()
        {
            _wheelieTimer = DateTime.Now;
        }

        public void Stop()
        {
            _wheelieTimer = default;
        }

        public bool IsStarted()
        {
            return _wheelieTimer.Ticks > 0;
        }

        public float GetSeconds()
        {
            var now = DateTime.Now;
            return (float)(now - _wheelieTimer).TotalMilliseconds / 1000;
        }
    }
}
