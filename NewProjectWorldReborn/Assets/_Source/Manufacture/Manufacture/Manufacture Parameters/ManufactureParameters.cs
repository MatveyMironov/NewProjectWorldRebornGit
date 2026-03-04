using ResourceSystem;
using System;
using System.Collections.Generic;

namespace ManufactureSystem
{
    internal class ManufactureParameters
    {
        public ManufactureParameters(int minManufactureTime,
                                     Dictionary<IResourceDefinition, int> consumedResources,
                                     Dictionary<IResourceDefinition, int> producedResources)
        {
            MinTime = minManufactureTime;
            ConsumedResources = consumedResources ?? throw new ArgumentNullException(nameof(consumedResources));
            ProducedResources = producedResources ?? throw new ArgumentNullException(nameof(producedResources));
        }

        public int MinTime { get; }
        public Dictionary<IResourceDefinition, int> ConsumedResources { get; }
        public Dictionary<IResourceDefinition, int> ProducedResources { get; }
    }
}