using System;
using System.Collections.Generic;

namespace ServiceSystem
{
    public class ServiceProvidersManager : IServiceProvidersManager
    {
        private readonly IServicesManager _servicesManager;

        public ServiceProvidersManager(IServicesManager servicesManager)
        {
            _servicesManager = servicesManager ?? throw new ArgumentNullException(nameof(servicesManager));
        }

        private readonly HashSet<ServiceProvider> _providers = new();

        public event Action<ServiceProvider> OnServiceProviderAdded;
        public event Action<ServiceProvider> OnServiceProviderRemoved;

        public bool TryAddServiceProvider(ServiceProvider serviceProvider)
        {
            if (!_providers.Add(serviceProvider)) return false;

            if (!_servicesManager.TryGetServiceBalance(serviceProvider.ProvidedService, out SuppliesManager serviceBalance))
            {
                if (!_servicesManager.TryAddServiceBalance(serviceProvider.ProvidedService, out serviceBalance))
                {
                    _providers.Remove(serviceProvider);
                    return false;
                }
            }

            if (!serviceBalance.TryAddSupply(serviceProvider))
            {
                _providers.Remove(serviceProvider);
                return false;
            }

            OnServiceProviderAdded?.Invoke(serviceProvider);
            return true;
        }

        public bool TryRemoveServiceProvider(ServiceProvider serviceProvider)
        {
            if (_providers.Remove(serviceProvider)) return false;

            if (_servicesManager.TryGetServiceBalance(serviceProvider.ProvidedService, out SuppliesManager serviceBalance))
            {
                serviceBalance.TryRemoveSupply(serviceProvider);
            }

            OnServiceProviderRemoved?.Invoke(serviceProvider);
            return true;
        }
    }
}