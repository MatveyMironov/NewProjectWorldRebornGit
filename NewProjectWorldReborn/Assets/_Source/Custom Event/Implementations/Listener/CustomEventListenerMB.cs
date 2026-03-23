using UnityEngine;
using UnityEngine.Events;

namespace CustomEventSystem.Implementations
{
    public class CustomEventListenerMB : MonoBehaviour
    {
        [SerializeField] private CustomEventSO customEvent;
        [SerializeField] private UnityEvent response;

        private void Awake()
        {
            customEvent.AddListener(InvokeResponse);
        }

        private void OnDestroy()
        {
            customEvent.RemoveListener(InvokeResponse);
        }

        private void InvokeResponse()
        {
            response.Invoke();
        }
    }
}