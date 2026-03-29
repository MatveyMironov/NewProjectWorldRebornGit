using EmployerManufactureSystem;
using EmployerSystem;
using ManufactureSystem;
using ResourceSystem;
using System;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    [CreateAssetMenu(fileName = "EmployerManufactureBuildingConfigurationSO", menuName = "Scriptable Objects/EmployerManufactureBuildingConfigurationSO")]
    public class EmployerManufactureBuildingConfigurationSO : ABuildingConfigurationSO
    {
        [SerializeField] private SResourceCountsDictionary consumedResources;
        [SerializeField] private SResourceCountsDictionary producedResources;
        [SerializeField] private int minTime;

        [SerializeField] private SEmployerConfiguration employerConfiguration;

        public static event Action<Building, IEmployer, IManufacture> OnBuildingCreated;

        public override Building CreateBuilding()
        {
            Building building = new(this, Construction.CreateBuildingStructure(), Info);
            IEmployer employer = employerConfiguration.GetEmployer();
            EmployerManufactureParameters parameters = new(consumedResources.GetResourceCountsDictionary(), producedResources.GetResourceCountsDictionary(), 1.0f / minTime, employer);
            Manufacture manufacture = new(parameters);
            OnBuildingCreated?.Invoke(building, employer, manufacture);
            return building;
        }
    }
}