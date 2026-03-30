using EmployerManufactureSystem;
using EmployerSystem;
using ManufactureSystem;
using ResourceSystem;
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

        public BuildingInterior CreateInterior()
        {
            IEmployer employer = employesWorkers ? employerConfiguration.GetEmployer() : null;

            IManufacture manufacture = null;
            if (carriesOutManufacture)
            {
                IManufactureParameters manufactureParameters;
                if (employer == null)
                {
                    manufactureParameters = new ManufactureParameters(1.0f / time, consumedResources.GetResourceCountsDictionary(), producedResources.GetResourceCountsDictionary());
                }
                else
                {
                    manufactureParameters = new EmployerManufactureParameters(consumedResources.GetResourceCountsDictionary(), producedResources.GetResourceCountsDictionary(), 1.0f / time, employer);
                }

                manufacture = new Manufacture(manufactureParameters);
            }
            
            return new(Name, Description, manufacture, employer);
        }
    }
}