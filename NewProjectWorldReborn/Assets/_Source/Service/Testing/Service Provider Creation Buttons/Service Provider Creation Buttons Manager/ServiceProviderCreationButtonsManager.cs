using ServiceSystem;
using System;
using System.Collections.Generic;

namespace ServiceSystem.Testing
{
    public class ServiceProviderCreationButtonsManager : IServiceProviderCreationButtonsManager
    {
        private readonly IServiceProvidersManager _serviceProvidersManager;
        private readonly IServiceProviderCreationButtonSpawner _creationButtonSpawner;
        private readonly IServiceProviderDisplayersManager _displayersManager;

        private readonly Dictionary<IServiceDefinition, IServiceProviderCreationButton> _buttons = new();
        private readonly Dictionary<IServiceProviderCreationButton, Action> _buttonActions = new();

        public ServiceProviderCreationButtonsManager(IServiceProvidersManager serviceProvidersManager,
                                                     IServiceProviderCreationButtonSpawner creationButtonSpawner,
                                                     IServiceProviderDisplayersManager displayersManager)
        {
            _serviceProvidersManager = serviceProvidersManager ?? throw new ArgumentNullException(nameof(serviceProvidersManager));
            _creationButtonSpawner = creationButtonSpawner ?? throw new ArgumentNullException(nameof(creationButtonSpawner));
            _displayersManager = displayersManager ?? throw new ArgumentNullException(nameof(displayersManager));
        }

        public bool TryAddButton(IServiceDefinition service, int providedAmount)
        {
            if (!_buttons.TryAdd(service, null)) return false;

            IServiceProviderCreationButton button = _creationButtonSpawner.SpawnButton();
            button.DisplayCreatedServiceSupply(service, providedAmount);
            _buttons[service] = button;

            if (_buttonActions.TryAdd(button, CreateServiceProvider))
            {
                button.OnButtonClicked += CreateServiceProvider;
            }

            return true;

            void CreateServiceProvider()
            {
                ServiceProvider serviceProvider = new(service, providedAmount);
                _serviceProvidersManager.TryAddServiceProvider(serviceProvider);
                _displayersManager.TryAddServiceProviderDisplayer(serviceProvider);
            }
        }

        public bool TryRemoveButton(IServiceDefinition service)
        {
            if (!_buttons.Remove(service, out IServiceProviderCreationButton button)) return false;

            button.Destroy();

            if (_buttonActions.Remove(button, out Action createServiceProvider))
            {
                button.OnButtonClicked -= createServiceProvider;
            }

            return true;
        }
    }
}
