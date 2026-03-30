using ServiceSystem;
using ManufactureSystem;
using ResourceSystem;
using EmployerSystem;
using System;
using UnityEngine;

namespace BuildingInteriorSystem
{
    [Serializable]
    public class SBuildingInteriorConfiguration : IBuildingInteriorConfiguration
    {
        [SerializeField] public string Name;
        [SerializeField] public string Description;

        [Space]
        [SerializeField] private bool employesWorkers;
        [SerializeField] private SEmployerConfiguration employerConfiguration;

        [Space]
        [SerializeField] private bool carriesOutManufacture;
        [SerializeField] private int time;
        [SerializeField] private SResourceCountsDictionary consumedResources;
        [SerializeField] private SResourceCountsDictionary producedResources;

        [Space]
        [SerializeField] private bool providesService;
        [SerializeField] private ServiceDefinitionSO providedService;
        [SerializeField] private int providedAmount;

        public BuildingInterior CreateInterior()
        {
            IEmployer employer = employesWorkers ? employerConfiguration.GetEmployer() : null;

            IManufacture manufacture = null;
            if (carriesOutManufacture)
            {
                ManufactureParameters manufactureParameters = new(1.0f / time, consumedResources.GetResourceCountsDictionary(), producedResources.GetResourceCountsDictionary());
                manufacture = new Manufacture(manufactureParameters);
            }

            ServiceProvider serviceProvider = providesService ? new(providedService, providedAmount) : null;
            
            return new(Name, Description, employer, manufacture, serviceProvider);
        }
    }
}