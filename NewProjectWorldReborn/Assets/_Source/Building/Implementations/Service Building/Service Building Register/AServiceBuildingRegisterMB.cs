using ServiceSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public abstract class AServiceBuildingRegisterMB : MonoBehaviour
    {
        protected abstract IServiceBuildingsManager ServiceBuildingsManager { get; }

        protected virtual void Start()
        {
            ServiceBuildingConfigurationSO.OnServiceBuildingCreated += AddServiceBuilding;
        }

        private void AddServiceBuilding(Building building, ServiceProvider serviceProvider)
        {
            if (ServiceBuildingsManager.TryAddServiceBuilding(building, serviceProvider))
            {
                
            }
        }

        private void RemoveServiceBuilding(Building building)
        {
            if (ServiceBuildingsManager.TryRemoveServiceBuilding(building))
            {

            }
        }
    }
}