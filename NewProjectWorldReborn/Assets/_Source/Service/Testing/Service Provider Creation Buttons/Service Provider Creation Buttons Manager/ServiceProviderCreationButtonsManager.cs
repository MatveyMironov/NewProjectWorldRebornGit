using System;
using System.Collections.Generic;

namespace ServiceSystem.Testing
{
    public class ServiceProviderCreationButtonsManager : IServiceProviderCreationButtonsManager
    {
        private readonly IServiceProvidersManager _serviceProvidersManager;
        private readonly IServiceProviderCreationButtonSpawner _creationButtonSpawner;

        public ServiceProviderCreationButtonsManager(IServiceProvidersManager serviceProvidersManager, IServiceProviderCreationButtonSpawner creationButtonSpawner)
        {
            _serviceProvidersManager = serviceProvidersManager ?? throw new ArgumentNullException(nameof(serviceProvidersManager));
            _creationButtonSpawner = creationButtonSpawner ?? throw new ArgumentNullException(nameof(creationButtonSpawner));
        }

        private readonly Dictionary<IServiceDefinition, IServiceProviderCreationButton> _buttons = new();

        public bool TryAddButton(IServiceDefinition service, int providedAmount)
        {
            if (_buttons.TryAdd(service, null))
            {
                _buttons[service] = _creationButtonSpawner.SpawnButton();
                _buttons[service].DisplayCreatedServiceSupply(service, providedAmount);
                _buttons[service].OnButtonClicked += CreateServiceProvider;

                return true;
            }

            return false;

            void CreateServiceProvider()
            {
                ServiceProvider serviceProvider = new(service, providedAmount);
                _serviceProvidersManager.TryAddServiceProvider(serviceProvider);
            }
        }

        public bool TryRemoveButton(IServiceDefinition service)
        {
            if (_buttons.Remove(service, out IServiceProviderCreationButton button))
            {
                button.Destroy();
                return true;
            }

            return false;
        }
    }
}