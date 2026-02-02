using ServiceSystem;
using System;
using System.Collections.Generic;

namespace BuildingSystem.Implementations
{
    public class ServiceBuildingsManager : IServiceBuildingsManager
    {
        private readonly IServiceProvidersManager _serviceProvidersManager;

        public ServiceBuildingsManager(IServiceProvidersManager serviceProvidersManager)
        {
            _serviceProvidersManager = serviceProvidersManager ?? throw new ArgumentNullException(nameof(serviceProvidersManager));
        }

        private readonly Dictionary<Building, ServiceProvider> _buildingsServiceProviders = new();

        public bool TryAddServiceBuilding(Building building, ServiceProvider serviceProvider)
        {
            if (_buildingsServiceProviders.TryAdd(building, serviceProvider))
            {
                _serviceProvidersManager.TryAddServiceProvider(serviceProvider);
                return true;
            }

            return false;
        }

        public bool TryRemoveServiceBuilding(Building building)
        {
            if (_buildingsServiceProviders.Remove(building, out ServiceProvider serviceProvider))
            {
                _serviceProvidersManager.TryRemoveServiceProvider(serviceProvider);
                return true;
            }

            return false;
        }
    }
}