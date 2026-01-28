using System;
using System.Collections.Generic;

namespace ServiceSystem
{
    public class ServiceProviderDisplayersManager : IServiceProviderDisplayersManager
    {
        private readonly IServiceProviderDisplayerSpawner _displayerSpawner;

        public ServiceProviderDisplayersManager(IServiceProviderDisplayerSpawner displayerSpawner)
        {
            _displayerSpawner = displayerSpawner ?? throw new ArgumentNullException(nameof(displayerSpawner));
        }

        private readonly Dictionary<ServiceProvider, AServiceProviderDisplayerMB> _displayers = new();

        public bool TryAddServiceProviderDisplayer(ServiceProvider provider)
        {
            if (_displayers.TryAdd(provider, null))
            {
                _displayers[provider] = _displayerSpawner.SpawnServiceProvider();
                _displayers[provider].DisplayServiceProvider(provider);
                return true;
            }

            return false;
        }

        public bool TryRemoveServiceProviderDisplayer(ServiceProvider provider)
        {
            if (_displayers.Remove(provider, out var displayer))
            {
                UnityEngine.Object.Destroy(displayer);
                return true;
            }

            return false;
        }
    }
}