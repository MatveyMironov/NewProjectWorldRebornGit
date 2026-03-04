using ResourceSystem;
using System;
using UnityEngine;

namespace ManufactureSystem
{
    [Serializable]
    public class SManufactureConfiguration : IManufactureConfiguration
    {
        [SerializeField] private int minTime;
        [SerializeField] private SResourceCountsDictionary consumedResources;
        [SerializeField] private SResourceCountsDictionary producedResources;

        public IManufacture CreateManufacture()
        {
            ManufactureParameters manufactureParameters = new(minTime,
                                                              consumedResources.GetResourceCountsDictionary(),
                                                              producedResources.GetResourceCountsDictionary());

            return new Manufacture(manufactureParameters);
        }
    }
}