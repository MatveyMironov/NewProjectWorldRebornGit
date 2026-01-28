using UnityEngine;

namespace ServiceSystem
{
    public class ServiceProviderDisplayerSpawnerMB : MonoBehaviour, IServiceProviderDisplayerSpawner
    {
        [SerializeField] private AServiceProviderDisplayerMB prefab;
        [SerializeField] private Transform parent;

        public AServiceProviderDisplayerMB SpawnServiceProvider()
        {
            return Instantiate(prefab, parent);
        }
    }
}