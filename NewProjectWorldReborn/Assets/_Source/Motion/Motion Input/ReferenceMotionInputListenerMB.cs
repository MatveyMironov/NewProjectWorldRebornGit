using Movement;
using Rotation;
using UnityEngine;
using UnityEngine.InputSystem;
using Zoom;

namespace MotionInput
{
    public class ReferenceMotionInputListenerMB : MonoBehaviour
    {
        [SerializeField] private MovementControllerMB movementController;
        [SerializeField] private RotationControllerMB rotationController;
        [SerializeField] private ZoomControllerMB zoomController;

        [SerializeField] private InputActionReference move;
        [SerializeField] private InputActionReference increaseSpeed;
        [SerializeField] private InputActionReference rotate;
        [SerializeField] private InputActionReference zoom;

        private void OnEnable()
        {
            //move.action.started += OnMove;
            move.action.performed += OnMove;
            move.action.canceled += OnMove;

            increaseSpeed.action.started += OnIncreaseSpeed;
            //increaseSpeed.action.performed += OnIncreaseSpeed;
            increaseSpeed.action.canceled += OnIncreaseSpeed;
            
            //rotate.action.started += OnRotate;
            rotate.action.performed += OnRotate;
            rotate.action.canceled += OnRotate;

            //zoom.action.started += OnZoom;
            zoom.action.performed += OnZoom;
            zoom.action.canceled += OnZoom;

            //Debug.Log("Motion input enabled");
        }

        private void OnDisable()
        {
            //move.action.started -= OnMove;
            move.action.performed -= OnMove;
            move.action.canceled -= OnMove;

            increaseSpeed.action.started -= OnIncreaseSpeed;
            //increaseSpeed.action.performed -= OnIncreaseSpeed;
            increaseSpeed.action.canceled -= OnIncreaseSpeed;

            //rotate.action.started -= OnRotate;
            rotate.action.performed -= OnRotate;
            rotate.action.canceled -= OnRotate;

            //zoom.action.started -= OnZoom;
            zoom.action.performed -= OnZoom;
            zoom.action.canceled -= OnZoom;

            //Debug.Log("Motion input disabled");
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();
            //Debug.Log($"Movement direction: {moveInput}");
            movementController.Move(moveInput);
        }

        private void OnIncreaseSpeed(InputAction.CallbackContext context)
        {
            bool encreaseSpeedInput = context.ReadValueAsButton();

            if (encreaseSpeedInput)
            {
                //Debug.Log("Increase speed");
                movementController.IncreaseSpeed();
            }
            else
            {
                //Debug.Log("Decrease speed");
                movementController.DecreaseSpeed();
            }
        }

        private void OnRotate(InputAction.CallbackContext context)
        {
            Vector2 rotateInput = context.ReadValue<Vector2>();
            //Debug.Log($"Rotation direction: {rotateInput}");
            rotationController.Rotate(rotateInput);
        }

        private void OnZoom(InputAction.CallbackContext context)
        {
            float zoomInput = context.ReadValue<float>();
            //Debug.Log($"Zoom: {zoomInput}");
            zoomController.Zoom(zoomInput);
        }
    }
}