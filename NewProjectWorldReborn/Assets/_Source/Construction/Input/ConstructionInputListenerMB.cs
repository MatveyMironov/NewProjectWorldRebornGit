using ConstructionControllerSystem;
using PlacingSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ConstructionInputSystem
{
    public class ConstructionInputListenerMB : MonoBehaviour
    {
        [SerializeField] private ConstructionControllerMB constructionController;
        [SerializeField] private BuildingRotationControllerMB buildingRotationController;

        public bool IsInputEnabled { get; set; } = true;

        private void OnExecuteConstructionAction(InputValue value)
        {
            if (!IsInputEnabled) return;

            if (value.isPressed)
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

        private void OnAbortConstructionAction(InputValue value)
        {
            if (!IsInputEnabled) return;

            if (value.isPressed)
            {
                //Debug.Log("Abort construction action");
                constructionController.ExitState();
            }
        }

        private void OnMoveMouse(InputValue value)
        {
            if (!IsInputEnabled) return;

            Vector2 movementInput = value.Get<Vector2>();
            //Debug.Log($"Mouse movement: {movementInput}");
            constructionController.UpdateMousePosition(movementInput);
        }

        private void OnRotateBuilding(InputValue value)
        {
            if (!IsInputEnabled) return;

            if (value.isPressed)
            {
                //Debug.Log("Rotate building");
                buildingRotationController.RotateBuilding();
            }
        }
    }
}