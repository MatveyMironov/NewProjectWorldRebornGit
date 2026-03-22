using ServiceSystem;
using System;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public abstract class AServiceBuildingRegisterMB : MonoBehaviour
    {
        protected abstract IServiceBuildingsManager ServiceBuildingsManager { get; }
        protected abstract IStructureBuildingsManager StructureBuildingsManager { get; }

        protected virtual void Start()
        {
            ServiceBuildingConfigurationSO.OnServiceBuildingCreated += RegisterServiceBuilding;
            StructureBuildingsManager.OnBuildingRemoved += UnregisterServiceBuilding;
        }

        private void OnDestroy()
        {
            ServiceBuildingConfigurationSO.OnServiceBuildingCreated -= RegisterServiceBuilding;
            StructureBuildingsManager.OnBuildingRemoved -= UnregisterServiceBuilding;
        }

        private void RegisterServiceBuilding(Building building, ServiceProvider serviceProvider)
        {
            if (ServiceBuildingsManager.TryAddServiceBuilding(building, serviceProvider))
            {
                //Debug.Log($"Service provider {serviceProvider} was added for building {building}");
            }
        }

        private void UnregisterServiceBuilding(Building building)
        {
            if (ServiceBuildingsManager.TryRemoveServiceBuilding(building))
            {
                //Debug.Log($"Service provider was removed of building {building}");
            }
        }
    }
}