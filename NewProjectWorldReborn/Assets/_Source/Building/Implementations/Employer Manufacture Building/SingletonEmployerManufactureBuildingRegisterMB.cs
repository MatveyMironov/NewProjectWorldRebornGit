using EmployerManufactureSystem;
using EmployerSystem;
using ManufactureSystem;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class SingletonEmployerManufactureBuildingRegisterMB : MonoBehaviour
    {
        private readonly Dictionary<Building, IEmployerManufacture> _buildings_employerManufactures = new();

        private readonly IManufacturesManager _manufacturesManager = ManufacturesManagerSingleton.Instance;
        private readonly IEmployersManager _employersManager = EmployersManagerSingleton.Instance;

        private readonly IStructureBuildingsManager _structureBuildingsManager = StructureBuildingsManagerSingleton.Instance;

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
            if (_buildings_employerManufactures.TryAdd(building, employerManufacture))
            {
                _manufacturesManager.TryAddManufacture(employerManufacture.Manufacture);
                _employersManager.TryAddEmployer(employerManufacture.Employer);
            }
        }

        private void UnregisterBuilding(Building building)
        {
            if (_buildings_employerManufactures.Remove(building, out IEmployerManufacture employerManufacture))
            {
                _manufacturesManager.TryRemoveManufacture(employerManufacture.Manufacture);
                _employersManager.TryRemoveEmployer(employerManufacture.Employer);
            }
        }
    }
}