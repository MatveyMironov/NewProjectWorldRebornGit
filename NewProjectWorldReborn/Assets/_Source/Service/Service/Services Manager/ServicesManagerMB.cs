using System;
using UnityEngine;

namespace ServiceSystem
{
    public class ServicesManagerMB : MonoBehaviour, IServicesManager
    {
        private IServicesManager _manager;

        private void Awake()
        {
            _manager = new ServicesManager();
        }

        public event Action<IServiceDefinition, SuppliesManager> OnServiceAdded
        {
            add { _manager.OnServiceAdded += value; }
            remove { _manager.OnServiceAdded -= value; }
        }

        public event Action<IServiceDefinition, SuppliesManager> OnServiceRemoved
        {
            add { _manager.OnServiceRemoved += value; }
            remove { _manager.OnServiceRemoved -= value; }
        }

        public bool TryAddServiceBalance(IServiceDefinition service, out SuppliesManager supply)
        {
            return _manager.TryAddServiceBalance(service, out supply);
        }

        public bool TryRemoveServiceBalance(IServiceDefinition service, out SuppliesManager supply)
        {
            return _manager.TryRemoveServiceBalance(service, out supply);
        }

        public bool TryGetServiceBalance(IServiceDefinition service, out SuppliesManager supply)
        {
            return _manager.TryGetServiceBalance(service, out supply);
        }
    }
}