using UnityEngine;
using UnityEngine.Events;

namespace CustomEventSystem.Implementations
{
    public class CustomEventUnityEventInvokerMB : MonoBehaviour
    {
        [SerializeField] private CustomEventSO customEvent;
        [SerializeField] private UnityEvent unityEvent;

        private void Awake()
        {
            customEvent.AddListener(InvokeUnityEvent);
        }

        private void OnDestroy()
        {
            customEvent.RemoveListener(InvokeUnityEvent);
        }

        private void InvokeUnityEvent()
        {
            unityEvent.Invoke();
        }
    }
}