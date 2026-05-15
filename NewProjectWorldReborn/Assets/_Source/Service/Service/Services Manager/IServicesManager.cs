using System;

namespace ServiceSystem
{
    public interface IServicesManager
    {
        event Action<IServiceDefinition, SuppliesManager> OnServiceAdded;

        SuppliesManager GetServiceSupply(IServiceDefinition service);
    }
}