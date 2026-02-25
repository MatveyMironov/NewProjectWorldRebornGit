using CustomUISystem;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace ServiceSystem.Testing
{
    public class ServiceProviderCreationButtonMB : MonoBehaviour, IServiceProviderCreationButton
    {
        [SerializeField] private Button button;
        [SerializeField] private AServiceDefinitionDisplayerMB serviceDefinitionDisplayer;
        [SerializeField] private ANumberDisplayerMB integerValueDisplayer;

        public event Action OnButtonClicked;

        private void Awake()
        {
            button.onClick.AddListener(InvokeButtonEvent);
        }

        public void DisplayCreatedServiceSupply(IServiceDefinition serviceDefinition, int suppliedAmount)
        {
            serviceDefinitionDisplayer.DisplayServiceDefinition(serviceDefinition);
            integerValueDisplayer.DisplayNumber(suppliedAmount);
        }

        public void HideCreatedServiceProvider()
        {
            serviceDefinitionDisplayer.Clear();
            integerValueDisplayer.DisplayNumber(0);
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }

        private void InvokeButtonEvent()
        {
            OnButtonClicked?.Invoke();
        }
    }
}