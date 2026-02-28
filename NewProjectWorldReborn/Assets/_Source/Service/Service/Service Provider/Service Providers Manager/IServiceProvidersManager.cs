using System;
using System.Collections.Generic;

namespace ServiceSystem
{
    public interface IServiceProvidersManager
    {
        HashSet<ServiceProvider> Providers { get; }

        event Action<ServiceProvider> OnServiceProviderAdded;
        event Action<ServiceProvider> OnServiceProviderRemoved;

        bool TryAddServiceProvider(ServiceProvider serviceProvider);
        bool TryRemoveServiceProvider(ServiceProvider serviceProvider);
    }
}