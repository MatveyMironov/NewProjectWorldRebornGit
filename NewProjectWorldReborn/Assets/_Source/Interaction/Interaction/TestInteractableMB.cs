using UnityEngine;

namespace InteractionSystem.Testing
{
    internal class TestInteractableMB : MonoBehaviour, IInteractable
    {
        [SerializeField] private GameObject interactionIndicator;

        private void Awake()
        {
            HideInteraction();
        }

        public void ShowInteraction()
        {
            interactionIndicator.SetActive(true);
        }

        public void HideInteraction()
        {
            interactionIndicator.SetActive(false);
        }

        public void Interact()
        {
            Debug.Log("Interact");
        }
    }
}