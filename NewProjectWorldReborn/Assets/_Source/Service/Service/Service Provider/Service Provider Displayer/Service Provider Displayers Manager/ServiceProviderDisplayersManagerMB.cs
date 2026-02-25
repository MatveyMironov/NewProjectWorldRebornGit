using UnityEngine;

namespace ServiceSystem
{
    public class ServiceProviderDisplayersManagerMB : MonoBehaviour, IServiceProviderDisplayersManager
    {
        [SerializeField] private ServiceProviderDisplayerSpawnerMB displayerSpawner;

        private IServiceProviderDisplayersManager _manager;

        private void Awake()
        {
            _manager = new ServiceProviderDisplayersManager(displayerSpawner);
        }

        public bool TryAddServiceProviderDisplayer(ServiceProvider serviceProvider)
        {
            return _manager.TryAddServiceProviderDisplayer(serviceProvider);
        }

        public bool TryRemoveServiceProviderDisplayer(ServiceProvider serviceProvider)
        {
            return _manager.TryRemoveServiceProviderDisplayer(serviceProvider);
        }
    }
}