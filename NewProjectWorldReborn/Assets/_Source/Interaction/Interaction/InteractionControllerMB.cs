using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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

        public event Action<IInteractable> OnInteractionSucceeded;
        public event Action OnInteractionFailed;

        public void Interact()
        {
            if (CheckIfMouseIsOverUI()) { return; }

            if (_targetInteractable == null)
            {
                OnInteractionFailed?.Invoke();
                return;
            }

            _targetInteractable.Interact();
            OnInteractionSucceeded?.Invoke(_targetInteractable);
        }

        public void ChangeMousePosition(Vector2 mousePosition)
        {
            if (_mousePosition == mousePosition) { return; }
            _mousePosition = mousePosition;

            if (CheckIfMouseIsOverUI())
            {
                ForgetColliderAndInteractable();
                return;
            }

            if (TryFindCollider(mousePosition, out Collider collider))
            {
                ChangeTargetCollider(collider);
            }
            else
            {
                ForgetColliderAndInteractable();
            }
            bool TryFindCollider(Vector2 mousePosition, out Collider collider)
            {
                Ray ray = interactionCamera.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, selectionDistance, selectedLayers))
                {
                    collider = hit.collider;
                    return true;
                }

                collider = null;
                return false;
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

        public void ForgetColliderAndInteractable()
        {
            _targetCollider = null;
            ForgetTargetInteractable();
        }

        private void ForgetTargetInteractable()
        {
            if (_targetInteractable != null)
            {
                _targetInteractable.HideInteraction();
                _targetInteractable = null;
            }
        }

        private bool CheckIfMouseIsOverUI()
        {
            return MouseOverUIChecker.CheckIfMouseIsOverUI();
        }
    }
}