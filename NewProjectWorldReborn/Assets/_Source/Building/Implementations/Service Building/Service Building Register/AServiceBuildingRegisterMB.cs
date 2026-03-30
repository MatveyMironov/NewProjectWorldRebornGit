using ServiceSystem;
using UnityEngine;

namespace BuildingSystem.Implementations.Service
{
    public abstract class AServiceBuildingRegisterMB : MonoBehaviour
    {
        protected abstract IStructureBuildingsManager BuildingsManager { get; }
        protected abstract IServiceProvidersManager ServiceProvidersManager { get; }

        protected virtual void Start()
        {
            BuildingsManager.OnBuildingAdded += RegisterServiceBuilding;
            BuildingsManager.OnBuildingRemoved += UnregisterServiceBuilding;
        }

        private void OnDestroy()
        {
            BuildingsManager.OnBuildingAdded -= RegisterServiceBuilding;
            BuildingsManager.OnBuildingRemoved -= UnregisterServiceBuilding;
        }

        private void RegisterServiceBuilding(Building building)
        {
            ServiceProvider serviceProvider = building.Interior.ServiceProvider;

            if (serviceProvider == null) { return; }

            if (ServiceProvidersManager.TryAddServiceProvider(serviceProvider))
            {
                //Debug.Log($"Service provider {serviceProvider} was added for building {building}");
            }
        }

        private void UnregisterServiceBuilding(Building building)
        {
            ServiceProvider serviceProvider = building.Interior.ServiceProvider;

            if (serviceProvider == null) { return; }

            if (ServiceProvidersManager.TryRemoveServiceProvider(serviceProvider))
            {
                //Debug.Log($"Service provider was removed of building {building}");
            }
        }
    }
}