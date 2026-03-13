using InteractionSystem;
using System;
using UnityEngine;

namespace BuildingViewSystem
{
    public class BuildingViewMB : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject demolitionIndicator;
        [SerializeField] private GameObject interactionIndicator;
        [SerializeField] private GameObject selectionIndicator;

        public event Action OnInteractionShown;
        public event Action OnInteractionHidden;
        public event Action OnInteracted;

        private bool _isInteractionShown;
        private bool _isSelected;

        private void Awake()
        {
            HideDemolition();
            HideInteraction();
            Deselect();
        }

        public void ShowDemolition()
        {
            demolitionIndicator.SetActive(true);
        }

        public void HideDemolition()
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
    }
}