using UnityEngine;
using UnityEngine.InputSystem;

namespace ConstructionControllerSystem.Input
{
    public class ConstructionControllerInputListenerMB : MonoBehaviour
    {
        [SerializeField] private ConstructionControllerMB constructionController;

        [Space]
        [SerializeField] private InputActionReference executeConstructionAction;
        [SerializeField] private InputActionReference exitConstructionState;
        [SerializeField] private InputActionReference moveMouse;

        private void OnEnable()
        {
            executeConstructionAction.action.started += OnExecuteConstructionActionInput;
            executeConstructionAction.action.canceled += OnExecuteConstructionActionInput;

            exitConstructionState.action.performed += OnExitConstructionStateInput;

            moveMouse.action.performed += OnMoveMouseInput;
        }

        private void OnDisable()
        {
            executeConstructionAction.action.started -= OnExecuteConstructionActionInput;
            executeConstructionAction.action.canceled -= OnExecuteConstructionActionInput;

            exitConstructionState.action.performed -= OnExitConstructionStateInput;

            moveMouse.action.performed -= OnMoveMouseInput;
        }

        private void OnExecuteConstructionActionInput(InputAction.CallbackContext context)
        {
            if (context.ReadValueAsButton())
            {
                //Debug.Log("Start construction action");
                constructionController.StartAction();
            }
            else
            {
                //Debug.Log("Execute construction action");
                constructionController.FinishAction();
            }
        }

        private void OnExitConstructionStateInput(InputAction.CallbackContext context)
        {
            //Debug.Log("Abort construction action");
            constructionController.ExitState();
        }

        private void OnMoveMouseInput(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            //Debug.Log($"Mouse movement: {movementInput}");
            constructionController.UpdateMousePosition(movementInput);
        }
    }
}