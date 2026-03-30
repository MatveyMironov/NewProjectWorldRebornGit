using ServiceSystem;
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
        [SerializeField] private bool providesService;
        [SerializeField] private ServiceDefinitionSO providedService;
        [SerializeField] private int providedAmount;

        public BuildingInterior CreateInterior()
        {
            ServiceProvider serviceProvider = providesService ? new(providedService, providedAmount) : null;
            return new(Name, Description, serviceProvider);
        }
    }
}