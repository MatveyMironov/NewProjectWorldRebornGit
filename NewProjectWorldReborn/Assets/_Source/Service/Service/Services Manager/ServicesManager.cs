using System;
using System.Collections.Generic;

namespace ServiceSystem
{
    public class ServicesManager : IServicesManager
    {
        private readonly Dictionary<IServiceDefinition, SuppliesManager> _services = new();

        public event Action<IServiceDefinition, SuppliesManager> OnServiceAdded;
        public event Action<IServiceDefinition, SuppliesManager> OnServiceRemoved;

        public bool TryAddServiceBalance(IServiceDefinition service, out SuppliesManager serviceBalance)
        {
            serviceBalance = null;

            if (_services.TryAdd(service, null))
            {
                serviceBalance = new();
                _services[service] = serviceBalance;
                OnServiceAdded?.Invoke(service, serviceBalance);
                return true;
            }

            return false;
        }

        public bool TryRemoveServiceBalance(IServiceDefinition service, out SuppliesManager serviceBalance)
        {
            if (_services.Remove(service, out serviceBalance))
            {
                OnServiceRemoved?.Invoke(service, serviceBalance);
                return true;
            }

            return false;
        }

        public bool TryGetServiceBalance(IServiceDefinition service, out SuppliesManager serviceBalance)
        {
            return _services.TryGetValue(service, out serviceBalance);
        }
    }
}