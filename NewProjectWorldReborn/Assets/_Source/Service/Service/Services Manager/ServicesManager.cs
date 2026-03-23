using System;
using System.Collections.Generic;

namespace ServiceSystem
{
    public class ServicesManager : IServicesManager
    {
        private readonly Dictionary<IServiceDefinition, SuppliesManager> _services_Supplies = new();

        public event Action<IServiceDefinition, SuppliesManager> OnServiceAdded;

        public SuppliesManager GetServiceSupply(IServiceDefinition service)
        {
            if (_services_Supplies.TryAdd(service, null))
            {
                _services_Supplies[service] = new();
                OnServiceAdded?.Invoke(service, _services_Supplies[service]);
            }

            return _services_Supplies[service];
        }
    }
}