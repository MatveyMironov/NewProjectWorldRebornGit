using UnityEngine;

namespace ServiceSystem.Testing
{
    public class ServiceProviderCreationButtonsManagerMB : MonoBehaviour, IServiceProviderCreationButtonsManager
    {
        [SerializeField] private ServiceProviderCreationButtonSpawnerMB creationButtonSpawner;

        private IServiceProviderCreationButtonsManager _manager;

        private void Awake()
        {
            _manager = new ServiceProviderCreationButtonsManager(ServiceProvidersManagerSingleton.Instance, creationButtonSpawner);
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