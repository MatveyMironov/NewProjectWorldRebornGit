using System;

namespace ServiceSystem
{
    public interface IServiceProvidersManager
    {
        event Action<ServiceProvider> OnServiceProviderAdded;
        event Action<ServiceProvider> OnServiceProviderRemoved;

        bool TryAddServiceProvider(ServiceProvider serviceProvider);
        bool TryRemoveServiceProvider(ServiceProvider serviceProvider);
    }
}