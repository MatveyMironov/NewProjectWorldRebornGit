using ResourceSystem;
using System;
using System.Collections.Generic;

namespace ManufactureSystem
{
    internal class ManufactureParameters : IManufactureParameters
    {
        public ManufactureParameters(int time,
                                     Dictionary<IResourceDefinition, int> consumedResources,
                                     Dictionary<IResourceDefinition, int> producedResources)
        {
            ConsumedResources = consumedResources ?? throw new ArgumentNullException(nameof(consumedResources));
            ProducedResources = producedResources ?? throw new ArgumentNullException(nameof(producedResources));
            Time = time;
        }

        public Dictionary<IResourceDefinition, int> ConsumedResources { get; }
        public Dictionary<IResourceDefinition, int> ProducedResources { get; }
        public float Time { get; }
    }
}