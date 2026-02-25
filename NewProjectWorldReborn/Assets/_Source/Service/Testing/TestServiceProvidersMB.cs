using System;
using UnityEngine;

namespace ServiceSystem.Testing
{
    public class TestServiceProvidersMB : MonoBehaviour
    {
        [SerializeField] private ServiceProviderConfiguration[] serviceProviderConfigurations = new ServiceProviderConfiguration[0];
        [SerializeField] private ServiceProviderCreationButtonsManagerMB serviceProviderCreationButtonsManager;

        private void Start()
        {
            foreach (var configuration in serviceProviderConfigurations)
            {
                serviceProviderCreationButtonsManager.TryAddButton(configuration.Service, configuration.ProvidedAmount);
            }
        }

        [Serializable]
        private struct ServiceProviderConfiguration
        {
            public ServiceDefinitionSO Service;
            public int ProvidedAmount;
        }
    }
}