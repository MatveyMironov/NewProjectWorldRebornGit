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

        public HashSet<ServiceProvider> Providers => new(_providers);

        public event Action<ServiceProvider> OnServiceProviderAdded;
        public event Action<ServiceProvider> OnServiceProviderRemoved;

        public bool TryAddServiceProvider(ServiceProvider serviceProvider)
        {
            if (_providers.Add(serviceProvider))
            {
                SuppliesManager supply = _servicesManager.GetServiceSupply(serviceProvider.ProvidedService);
                supply.TryAddSupply(serviceProvider);
                OnServiceProviderAdded?.Invoke(serviceProvider);
                return true;
            }

            return false;
        }

        public bool TryRemoveServiceProvider(ServiceProvider serviceProvider)
        {
            if (_providers.Remove(serviceProvider))
            {
                SuppliesManager supply = _servicesManager.GetServiceSupply(serviceProvider.ProvidedService);
                supply.TryRemoveSupply(serviceProvider);
                OnServiceProviderRemoved?.Invoke(serviceProvider);
                return true;
            }

            return false;
        }
    }
}