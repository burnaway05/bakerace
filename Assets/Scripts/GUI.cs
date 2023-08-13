using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core
{
    internal class GUI : MonoBehaviour
    {
        [SerializeField] private EventTrigger _right;
        [SerializeField] private EventTrigger _left;
        [SerializeField] private Text _distance;
        [SerializeField] private Text _wheelie;
        private Stopwatch _wheelieStopwatch;

        private void Start()
        {
            InitializeTriggers();
            HideWheelie();
            _wheelieStopwatch = new Stopwatch();
        }

        private void InitializeTriggers()
        {
            EventTrigger.Entry rightDown = new EventTrigger.Entry();
            rightDown .eventID = EventTriggerType.PointerDown;
            rightDown.callback.AddListener((eventData) => { Run.Instance.Game.Accelerate(); });
            _right.triggers.Add(rightDown);

            EventTrigger.Entry rightUp = new EventTrigger.Entry();
            rightUp.eventID = EventTriggerType.PointerUp;
            rightUp.callback.AddListener((eventData) => { Run.Instance.Game.StopAccelerate(); });
            _right.triggers.Add(rightUp);

            EventTrigger.Entry leftDown = new EventTrigger.Entry();
            leftDown.eventID = EventTriggerType.PointerDown;
            leftDown.callback.AddListener((eventData) => { Run.Instance.Game.Brake(); });
            _left.triggers.Add(leftDown);

            EventTrigger.Entry leftUp = new EventTrigger.Entry();
            leftUp.eventID = EventTriggerType.PointerUp;
            leftUp.callback.AddListener((eventData) => { Run.Instance.Game.StopBrake(); });
            _left.triggers.Add(leftUp);
        }

        private void Update()
        {
            if (_wheelieStopwatch.IsStarted() && _wheelieStopwatch.GetSeconds() > 1)
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