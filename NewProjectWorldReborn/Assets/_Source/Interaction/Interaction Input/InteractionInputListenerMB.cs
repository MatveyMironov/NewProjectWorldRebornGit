using UnityEngine;
using UnityEngine.InputSystem;

namespace InteractionSystem.Input
{
    public class InteractionInputListenerMB : MonoBehaviour
    {
        [SerializeField] private InputActionReference interactInput;
        [SerializeField] private InputActionReference mousePositionInput;

        [Space]
        [SerializeField] private InteractionControllerMB interactionController;

        private void OnEnable()
        {
            interactInput.action.performed += OnInteractInput;

            mousePositionInput.action.started += OnMousePositionInput;
            mousePositionInput.action.performed += OnMousePositionInput;
        }

        private void OnDisable()
        {
            interactInput.action.performed -= OnInteractInput;

            mousePositionInput.action.started -= OnMousePositionInput;
            mousePositionInput.action.performed -= OnMousePositionInput;
        }

        private void OnInteractInput(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                //Debug.Log("Interact");
                interactionController.Interact();
            }
        }

        private void OnMousePositionInput(InputAction.CallbackContext context)
        {
            Vector2 mousePosition = context.ReadValue<Vector2>();
            //Debug.Log($"Mouse position: {mousePosition}");
            interactionController.ChangeMousePosition(mousePosition);
        }
    }
}