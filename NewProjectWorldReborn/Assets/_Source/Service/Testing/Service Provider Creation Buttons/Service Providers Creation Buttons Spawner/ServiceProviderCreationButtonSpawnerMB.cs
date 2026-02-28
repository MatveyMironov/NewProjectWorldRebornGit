using UnityEngine;

namespace ServiceSystem.Testing
{
    public class ServiceProviderCreationButtonSpawnerMB : MonoBehaviour, IServiceProviderCreationButtonSpawner
    {
        [SerializeField] private ServiceProviderCreationButtonMB prefab;
        [SerializeField] private Transform parent;

        public IServiceProviderCreationButton SpawnButton()
        {
            return Instantiate(prefab, parent);
        }
    }
}