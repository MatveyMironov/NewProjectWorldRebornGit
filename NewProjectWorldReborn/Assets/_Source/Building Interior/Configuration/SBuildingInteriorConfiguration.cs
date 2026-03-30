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

        public BuildingInterior CreateInterior()
        {
            IEmployer employer = employesWorkers ? employerConfiguration.GetEmployer() : null;

            return new(Name, Description, employer);
        }
    }
}