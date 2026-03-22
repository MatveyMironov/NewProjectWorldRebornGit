using Movement;
using Rotation;
using UnityEngine;
using UnityEngine.InputSystem;
using Zoom;

namespace MotionInput
{
    public class MotionInputListenerMB : MonoBehaviour
    {
        [SerializeField] private MovementControllerMB movementController;
        [SerializeField] private RotationControllerMB rotationController;
        [SerializeField] private ZoomControllerMB zoomController;

        private void OnMove(InputValue value)
        {
            Vector2 moveInput = value.Get<Vector2>();
            //Debug.Log($"Movement direction: {moveInput}");
            movementController.Move(moveInput);
        }

        private void OnIncreaseSpeed(InputValue value)
        {
            bool encreaseSpeedInput = value.isPressed;

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

        private void OnRotate(InputValue value)
        {
            Vector2 rotateInput = value.Get<Vector2>();
            //Debug.Log($"Rotation direction: {rotateInput}");
            rotationController.Rotate(rotateInput);
        }

        private void OnZoom(InputValue value)
        {
            float zoomInput = value.Get<float>();
            //Debug.Log($"Zoom: {zoomInput}");
            zoomController.Zoom(zoomInput);
        }
    }
}