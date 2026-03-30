using ManufactureSystem;
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
        [SerializeField] private bool hasManufacture;
        [SerializeField] private SManufactureConfiguration manufactureConfiguration;

        public BuildingInterior CreateInterior()
        {
            IManufacture manufacture = hasManufacture ? manufactureConfiguration.CreateManufacture() : null;

            return new(Name, Description, manufacture);
        }
    }
}