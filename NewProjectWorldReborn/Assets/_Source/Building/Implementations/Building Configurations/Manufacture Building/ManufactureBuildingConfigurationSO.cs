using EfficiencySystem;
using ManufactureSystem;
using System;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Manufacture Building", menuName = "Building Configuration/Manufacture Building")]
    public class ManufactureBuildingConfigurationSO : ABuildingConfigurationSO
    {
        [Space]
        [SerializeField] SManufactureConfiguration manufactureConfiguration;

        public static event Action<Building, IManufacture> OnManufactureBuildingCreated;

        public override Building CreateBuilding()
        {
            Building building = new(Construction.CreateBuildingStructure(), Info);
            IManufacture manufacture = manufactureConfiguration.CreateManufacture(new ConstantEfficiency());
            OnManufactureBuildingCreated?.Invoke(building, manufacture);
            return building;
        }
    }
}