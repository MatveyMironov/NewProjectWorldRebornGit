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

        public bool TryAddDisplayer(ServiceProvider serviceProvider)
        {
            return _manager.TryAddDisplayer(serviceProvider);
        }

        public bool TryRemoveDisplayer(ServiceProvider serviceProvider)
        {
            return _manager.TryRemoveDisplayer(serviceProvider);
        }

        public void RemoveAllDisplayers()
        {
            _manager.RemoveAllDisplayers();
        }
    }
}