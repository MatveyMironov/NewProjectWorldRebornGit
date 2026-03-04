using UnityEngine;

namespace BuildingSystem.Implementations
{
    public abstract class AConfigurationBuildingsManagerSetuperMB : MonoBehaviour
    {
        protected abstract IConfigurationBuildingsManager ConfigurationBuildingsManager { get; }
        protected abstract IStructureBuildingsManager StructureBuildingsManager { get; }

        protected virtual void Start()
        {
            StructureBuildingsManager.OnBuildingAdded += AddBuilding;
            StructureBuildingsManager.OnBuildingRemoved += RemoveBuilding;
        }

        protected virtual void OnDestroy()
        {
            StructureBuildingsManager.OnBuildingAdded -= AddBuilding;
            StructureBuildingsManager.OnBuildingRemoved -= RemoveBuilding;
        }

        private void AddBuilding(Building building)
        {
            ConfigurationBuildingsManager.TryAddBuilding(building);
        }

        private void RemoveBuilding(Building building)
        {
            ConfigurationBuildingsManager.TryRemoveBuilding(building);
        }
    }
}