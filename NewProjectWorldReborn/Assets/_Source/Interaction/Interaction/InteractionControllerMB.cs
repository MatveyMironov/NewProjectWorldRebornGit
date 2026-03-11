using UnityEngine;

namespace InteractionSystem
{
    public class InteractionControllerMB : MonoBehaviour
    {
        [SerializeField] private float selectionDistance;
        [SerializeField] private LayerMask selectedLayers;

        private Camera _mainCamera;

        private Vector2 _mousePosition;
        private Collider _targetCollider;
        private IInteractable _targetInteractable;

        private void Awake()
        {
            _mainCamera = Camera.main;
        }

        public void Interact()
        {
            if (_targetInteractable == null) return;

            _targetInteractable.Interact();
        }

        public void ChangeMousePosition(Vector2 mousePosition)
        {
            if (_mousePosition == mousePosition) return;
            _mousePosition = mousePosition;

            Ray ray = _mainCamera.ScreenPointToRay(_mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, selectionDistance, selectedLayers))
            {
                ChangeTargetCollider(hit.collider);
            }
        }

        private void ChangeTargetCollider(Collider collider)
        {
            if (_targetCollider == collider) return;
            _targetCollider = collider;

            if (collider.TryGetComponent(out IInteractable interactable))
            {
                ChangeTargetInteractable(interactable);
            }
        }

        private void ChangeTargetInteractable(IInteractable interactable)
        {
            if (_targetInteractable != null)
            {
                if (_targetInteractable == interactable) return;

                _targetInteractable.HideInteraction();
            }

            interactable.ShowInteraction();
            _targetInteractable = interactable;
        }
    }
}