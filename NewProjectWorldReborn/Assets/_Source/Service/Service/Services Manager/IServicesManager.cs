using System;

namespace ServiceSystem
{
    public interface IServicesManager
    {
        event Action<IServiceDefinition, SuppliesManager> OnServiceAdded;
        event Action<IServiceDefinition, SuppliesManager> OnServiceRemoved;

        bool TryAddServiceBalance(IServiceDefinition service, out SuppliesManager serviceBalance);
        bool TryRemoveServiceBalance(IServiceDefinition service, out SuppliesManager serviceBalance);
        bool TryGetServiceBalance(IServiceDefinition service, out SuppliesManager serviceBalance);
    }
}