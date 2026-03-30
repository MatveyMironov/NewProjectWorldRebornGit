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
        [SerializeField] private bool carriesOutManufacture;
        [SerializeField] private int time;
        [SerializeField] private SResourceCountsDictionary consumedResources;
        [SerializeField] private SResourceCountsDictionary producedResources;

        public BuildingInterior CreateInterior()
        {
            IManufacture manufacture = null;
            if (carriesOutManufacture)
            {
                ManufactureParameters manufactureParameters = new(1.0f / time, consumedResources.GetResourceCountsDictionary(), producedResources.GetResourceCountsDictionary());
                manufacture = new Manufacture(manufactureParameters);
            }

            return new(Name, Description, manufacture);
        }
    }
}