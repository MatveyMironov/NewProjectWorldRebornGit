using ResourceSystem;
using System;
using UnityEngine;

namespace ManufactureSystem
{
    [Serializable]
    public class SManufactureConfiguration : IManufactureConfiguration
    {
        [SerializeField] private int time;
        [SerializeField] private SResourceCountsDictionary consumedResources;
        [SerializeField] private SResourceCountsDictionary producedResources;

        public IManufacture CreateManufacture()
        {
            ManufactureParameters manufactureParameters = new(1.0f / time,
                                                              consumedResources.GetResourceCountsDictionary(),
                                                              producedResources.GetResourceCountsDictionary());

            return new Manufacture(manufactureParameters);
        }
    }
}