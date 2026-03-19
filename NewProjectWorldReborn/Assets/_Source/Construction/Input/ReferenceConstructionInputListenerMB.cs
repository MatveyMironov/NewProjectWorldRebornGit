using ConstructionControllerSystem;
using DemolishingSystem;
using PlacingSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ConstructionInputSystem
{
    public class ReferenceConstructionInputListenerMB : MonoBehaviour
    {
        [SerializeField] private ConstructionControllerMB constructionController;
        [SerializeField] private BuildingRotationControllerMB buildingRotationController;
        [SerializeField] private DemolitionControllerMB demolitionController;

        [Space]
        [SerializeField] private InputActionReference executeConstructionAction;
        [SerializeField] private InputActionReference abortConstructionAction;
        [SerializeField] private InputActionReference moveMouse;
        [SerializeField] private InputActionReference rotateBuilding;
        [SerializeField] private InputActionReference startDemolishing;

        private void OnEnable()
        {
            executeConstructionAction.action.started += OnExecuteConstructionActionInput;
            executeConstructionAction.action.canceled += OnExecuteConstructionActionInput;

            abortConstructionAction.action.performed += OnAbortConstructionActionInput;

            moveMouse.action.performed += OnMoveMouseInput;

            rotateBuilding.action.performed += OnRotateBuildingInput;

            startDemolishing.action.performed += OnStartDemolishingInput;
        }

        private void OnDisable()
        {
            executeConstructionAction.action.started -= OnExecuteConstructionActionInput;
            executeConstructionAction.action.canceled -= OnExecuteConstructionActionInput;

            abortConstructionAction.action.performed -= OnAbortConstructionActionInput;

            moveMouse.action.performed -= OnMoveMouseInput;

            rotateBuilding.action.performed -= OnRotateBuildingInput;

            startDemolishing.action.performed -= OnStartDemolishingInput;
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

        private void OnAbortConstructionActionInput(InputAction.CallbackContext context)
        {
            //Debug.Log("Abort construction action");
            constructionController.AbortAction();
        }

        private void OnMoveMouseInput(InputAction.CallbackContext context)
        {
            Vector2 movementInput = context.ReadValue<Vector2>();
            //Debug.Log($"Mouse movement: {movementInput}");
            constructionController.UpdateMousePosition(movementInput);
        }

        private void OnRotateBuildingInput(InputAction.CallbackContext context)
        {
            //Debug.Log("Rotate building");
            buildingRotationController.RotateBuilding();
        }

        private void OnStartDemolishingInput(InputAction.CallbackContext context)
        {
            //Debug.Log("Start demolishing");
            demolitionController.StartDemolishing();
        }
    }
}