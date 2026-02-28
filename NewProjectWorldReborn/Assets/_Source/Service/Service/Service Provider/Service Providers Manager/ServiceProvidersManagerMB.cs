using System;
using System.Collections.Generic;
using UnityEngine;

namespace ServiceSystem
{
    public class ServiceProvidersManagerMB : MonoBehaviour, IServiceProvidersManager
    {
        [SerializeField] private ServicesManagerMB servicesManager;

        private IServiceProvidersManager _manager;

        public HashSet<ServiceProvider> Providers => _manager.Providers;

        public event Action<ServiceProvider> OnServiceProviderAdded
        {
            add { _manager.OnServiceProviderAdded += value; }
            remove { _manager.OnServiceProviderAdded -= value; }
        }

        public event Action<ServiceProvider> OnServiceProviderRemoved
        {
            add { _manager.OnServiceProviderRemoved += value; }
            remove { _manager.OnServiceProviderRemoved -= value; }
        }

        private void Awake()
        {
            _manager = new ServiceProvidersManager(servicesManager);
        }

        public bool TryAddServiceProvider(ServiceProvider serviceProvider)
        {
            return _manager.TryAddServiceProvider(serviceProvider);
        }

        public bool TryRemoveServiceProvider(ServiceProvider serviceProvider)
        {
            return _manager.TryRemoveServiceProvider(serviceProvider);
        }
    }
}