using EmployerManufactureSystem;
using System;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    [CreateAssetMenu(fileName = "EmployerManufactureBuildingConfigurationSO", menuName = "Scriptable Objects/EmployerManufactureBuildingConfigurationSO")]
    public class EmployerManufactureBuildingConfigurationSO : ABuildingConfigurationSO
    {
        [SerializeField] private SEmployerManufactureConfiguration employerManufactureConfiguration;

        public static event Action<Building, IEmployerManufacture> OnBuildingCreated;

        public override Building CreateBuilding()
        {
            Building building = new(this, Construction.CreateBuildingStructure(), Info);
            IEmployerManufacture employerManufacture = employerManufactureConfiguration.CreateEmployerManufacture();
            OnBuildingCreated?.Invoke(building, employerManufacture);
            return building;
        }
    }
}