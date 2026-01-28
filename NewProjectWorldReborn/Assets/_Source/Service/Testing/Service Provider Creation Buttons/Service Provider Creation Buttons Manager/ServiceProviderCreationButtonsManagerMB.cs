using ServiceSystem;
using UnityEngine;

namespace ServiceSystem.Testing
{
    public class ServiceProviderCreationButtonsManagerMB : MonoBehaviour, IServiceProviderCreationButtonsManager
    {
        [SerializeField] private ServiceProviderCreationButtonSpawnerMB creationButtonSpawner;
        [SerializeField] private ServiceProviderDisplayersManagerMB displayersManager;

        private IServiceProviderCreationButtonsManager _manager;

        private void Awake()
        {
            IServiceProvidersManager serviceProvidersManager = ServiceProvidersManagerSingleton.Instance;

            _manager = new ServiceProviderCreationButtonsManager(serviceProvidersManager, creationButtonSpawner, displayersManager);
        }

        public bool TryAddButton(IServiceDefinition service, int providedAmount)
        {
            return _manager.TryAddButton(service, providedAmount);
        }

        public bool TryRemoveButton(IServiceDefinition service)
        {
            return _manager.TryRemoveButton(service);
        }
    }
}
