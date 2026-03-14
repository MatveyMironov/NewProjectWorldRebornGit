using ServiceSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BuildingSystem.Implementations
{
    public class ServiceBuildingsManager : IServiceBuildingsManager
    {
        private readonly IServiceProvidersManager _serviceProvidersManager;

        public ServiceBuildingsManager(IServiceProvidersManager serviceProvidersManager)
        {
            _serviceProvidersManager = serviceProvidersManager ?? throw new ArgumentNullException(nameof(serviceProvidersManager));
        }

        private readonly Dictionary<Building, ServiceProvider> _buildings_ServiceProviders = new();

        public Building[] Buildings => _buildings_ServiceProviders.Keys.ToArray();
        public event Action<Building> OnBuildingAdded;
        public event Action<Building> OnBuildingRemoved;

        public bool TryAddServiceBuilding(Building building, ServiceProvider serviceProvider)
        {
            if (_buildings_ServiceProviders.TryAdd(building, serviceProvider))
            {
                _serviceProvidersManager.TryAddServiceProvider(serviceProvider);
                return true;
            }

            return false;
        }

        public bool TryRemoveServiceBuilding(Building building)
        {
            if (_buildings_ServiceProviders.Remove(building, out ServiceProvider serviceProvider))
            {
                _serviceProvidersManager.TryRemoveServiceProvider(serviceProvider);
                return true;
            }

            return false;
        }

        public bool TryGetBuildingServiceProvider(Building building, out ServiceProvider serviceProvider)
        {
            return _buildings_ServiceProviders.TryGetValue(building, out serviceProvider);
        }
    }
}