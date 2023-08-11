using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Core
{
    internal class GUI : MonoBehaviour
    {
        [SerializeField] private EventTrigger _right;
        [SerializeField] private EventTrigger _left;

        private void Start()
        {
            InitializeTriggers();
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
    }
}