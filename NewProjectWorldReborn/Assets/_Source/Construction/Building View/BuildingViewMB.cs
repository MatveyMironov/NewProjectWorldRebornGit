using InteractionSystem;
using System;
using UnityEngine;

namespace BuildingViewSystem
{
    public class BuildingViewMB : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject interactionIndicator;
        [SerializeField] private GameObject selectionIndicator;
        [SerializeField] private GameObject demolitionIndicator;

        public event Action OnInteractionShown;
        public event Action OnInteractionHidden;
        public event Action OnInteracted;

        public event Action OnSelectedForDemolition;
        public event Action OnDeselectedForDemolition;
        
        private bool _isInteractionShown;
        private bool _isSelected;

        private void Awake()
        {
            OnDeselectForDemolition();
            HideInteraction();
            Deselect();
        }

        public void OnSelectForDemolition()
        {
            demolitionIndicator.SetActive(true);
        }

        public void OnDeselectForDemolition()
        {
            demolitionIndicator.SetActive(false);
        }

        public void ShowInteraction()
        {
            _isInteractionShown = true;

            if (!_isSelected)
            {
                interactionIndicator.SetActive(true);
            }

            OnInteractionShown?.Invoke();
        }

        public void HideInteraction()
        {
            _isInteractionShown = false;
            interactionIndicator.SetActive(false);
            OnInteractionHidden?.Invoke();
        }

        public void Interact()
        {
            OnInteracted?.Invoke();
        }

        public void Select()
        {
            _isSelected = true;
            selectionIndicator.SetActive(true);

            if (_isInteractionShown)
            {
                HideInteraction();
            }
        }

        public void Deselect()
        {
            _isSelected = false;
            selectionIndicator.SetActive(false);

            if (_isInteractionShown)
            {
                ShowInteraction();
            }
        }
        
        public void Demolish()
        {
            Destroy(gameObject);
        }
    }
}