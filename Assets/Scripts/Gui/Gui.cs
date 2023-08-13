using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Utils;

namespace Gui
{
    public interface IBikeRaceGui
    {
        void Initialize(IBikeControl bikeController);
        void UpdateDistance(float distance);
        void ShowWheelie();
        void HideWheelie();
    }

    public interface IBikeControl
    {
        void Accelerate();
        void StopAccelerate();
        void Brake();
        void StopBrake();
    }

    public class Gui : MonoBehaviour, IBikeRaceGui
    {
        [SerializeField] private EventTrigger _right;
        [SerializeField] private EventTrigger _left;
        [SerializeField] private Text _distance;
        [SerializeField] private Text _wheelie;
        private const float ShowingWheelie = 0.8f;
        private IStopwatch _wheelieStopwatch;

        private void Start()
        {
            HideWheelie();
            _wheelieStopwatch = new Stopwatch();
        }

        public void Initialize(IBikeControl bikeController)
        {
            EventTrigger.Entry rightDown = new EventTrigger.Entry();
            rightDown .eventID = EventTriggerType.PointerDown;
            rightDown.callback.AddListener((eventData) => { bikeController.Accelerate(); });
            _right.triggers.Add(rightDown);

            EventTrigger.Entry rightUp = new EventTrigger.Entry();
            rightUp.eventID = EventTriggerType.PointerUp;
            rightUp.callback.AddListener((eventData) => { bikeController.StopAccelerate(); });
            _right.triggers.Add(rightUp);

            EventTrigger.Entry leftDown = new EventTrigger.Entry();
            leftDown.eventID = EventTriggerType.PointerDown;
            leftDown.callback.AddListener((eventData) => { bikeController.Brake(); });
            _left.triggers.Add(leftDown);

            EventTrigger.Entry leftUp = new EventTrigger.Entry();
            leftUp.eventID = EventTriggerType.PointerUp;
            leftUp.callback.AddListener((eventData) => { bikeController.StopBrake(); });
            _left.triggers.Add(leftUp);
        }

        private void Update()
        {
            if (_wheelieStopwatch.IsStarted() && _wheelieStopwatch.GetSeconds() > ShowingWheelie)
            {
                _wheelieStopwatch.Stop();
                HideWheelie();
            }
        }

        public void UpdateDistance(float distance)
        {
            _distance.text = Mathf.Round(distance).ToString();
        }

        public void ShowWheelie()
        {
            _wheelie.gameObject.SetActive(true);
            _wheelieStopwatch.Start();
        }

        public void HideWheelie()
        {
            _wheelie.gameObject.SetActive(false);
        }
    }
}