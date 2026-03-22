using EmployerManufactureSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class SingletonEmployerManufactureBuildingRegisterMB : MonoBehaviour
    {
        private readonly IStructureBuildingsManager _structureBuildingsManager = StructureBuildingsManagerSingleton.Instance;

        private readonly IBuildingEmployerManufacturesManager _buildingEmployerManufacturesManager = BuildingEmployerManufacturesManagerSingleton.Instance;

        private void OnEnable()
        {
            EmployerManufactureBuildingConfigurationSO.OnBuildingCreated += RegisterBuilding;
            _structureBuildingsManager.OnBuildingRemoved += UnregisterBuilding;
        }

        private void OnDisable()
        {
            EmployerManufactureBuildingConfigurationSO.OnBuildingCreated -= RegisterBuilding;
            _structureBuildingsManager.OnBuildingRemoved -= UnregisterBuilding;
        }

        private void RegisterBuilding(Building building, IEmployerManufacture employerManufacture)
        {
            _buildingEmployerManufacturesManager.TryAddBuildingEmployerManufacture(building, employerManufacture);
        }

        private void UnregisterBuilding(Building building)
        {
            _buildingEmployerManufacturesManager.TryRemoveBuildingEmployerManufacture(building);
        }
    }
}