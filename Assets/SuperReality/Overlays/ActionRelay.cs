using UnityEngine;
using UnityEngine.Events;

namespace SuperReality.Overlays
{
    public class ActionRelay : MonoBehaviour
    {
        [SerializeField]
        private string actionName;

        [SerializeField]
        private UnityEvent onActionReceived;

        public string ActionName => actionName;

        public void ReceiveAction()
        {
            onActionReceived.Invoke();
        }
    }
}
