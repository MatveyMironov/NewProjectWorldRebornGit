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
            add => _manager.OnServiceAdded += value;
            remove => _manager.OnServiceAdded -= value;
        }

        public SuppliesManager GetServiceSupply(IServiceDefinition service)
        {
            return _manager.GetServiceSupply(service);
        }
    }
}