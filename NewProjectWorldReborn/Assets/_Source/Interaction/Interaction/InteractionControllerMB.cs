using UnityEngine;

namespace InteractionSystem
{
    public class InteractionControllerMB : MonoBehaviour
    {
        [SerializeField] private float selectionDistance;
        [SerializeField] private LayerMask selectedLayers;
        [SerializeField] private Camera interactionCamera;

        private Vector2 _mousePosition;
        private Collider _targetCollider;
        private IInteractable _targetInteractable;

        public void Interact()
        {
            if (_targetInteractable == null) return;

            _targetInteractable.Interact();
        }

        public void ChangeMousePosition(Vector2 mousePosition)
        {
            if (_mousePosition == mousePosition) { return; }
            _mousePosition = mousePosition;

            Ray ray = interactionCamera.ScreenPointToRay(_mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, selectionDistance, selectedLayers))
            {
                ChangeTargetCollider(hit.collider);
            }
            else
            {
                _targetCollider = null;
                ForgetTargetInteractable();
            }
        }

        private void ChangeTargetCollider(Collider collider)
        {
            if (_targetCollider == collider) { return; }
            _targetCollider = collider;

            if (collider.TryGetComponent(out IInteractable interactable))
            {
                ChangeTargetInteractable(interactable);
            }
            else
            {
                ForgetTargetInteractable();
            }
        }

        private void ChangeTargetInteractable(IInteractable interactable)
        {
            if (_targetInteractable != null)
            {
                if (_targetInteractable == interactable) { return; }

                _targetInteractable.HideInteraction();
            }

            _targetInteractable = interactable;
            interactable.ShowInteraction();
        }

        private void ForgetTargetInteractable()
        {
            if (_targetInteractable != null)
            {
                _targetInteractable.HideInteraction();
                _targetInteractable = null;
            }
        }
    }
}