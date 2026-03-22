using CustomEventSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CustomEventInputSystem
{
    public class CustomEventInputListenerMB : MonoBehaviour
    {
        [SerializeField] private InputActionReference inputAction;
        [SerializeField] private CustomEventSO customEvent;

        private void OnEnable()
        {
            inputAction.action.performed += CallEvent;
            inputAction.action.Enable();
        }

        private void OnDisable()
        {
            inputAction.action.performed -= CallEvent;
            inputAction.action.Disable();
        }

        private void CallEvent(InputAction.CallbackContext context)
        {
            customEvent.Call();
        }
    }
}
