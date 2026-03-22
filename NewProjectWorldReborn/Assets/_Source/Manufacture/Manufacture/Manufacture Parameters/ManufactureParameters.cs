using ResourceSystem;
using System;
using System.Collections.Generic;

namespace ManufactureSystem
{
    internal class ManufactureParameters : IManufactureParameters
    {
        public ManufactureParameters(float speed,
                                     Dictionary<IResourceDefinition, int> consumedResources,
                                     Dictionary<IResourceDefinition, int> producedResources)
        {
            ConsumedResources = consumedResources ?? throw new ArgumentNullException(nameof(consumedResources));
            ProducedResources = producedResources ?? throw new ArgumentNullException(nameof(producedResources));
            Speed = speed <= 0.0f ? throw new ArgumentOutOfRangeException("Manufacture speed can't be equal to or less then 0") : speed;
        }

        public Dictionary<IResourceDefinition, int> ConsumedResources { get; }
        public Dictionary<IResourceDefinition, int> ProducedResources { get; }
        public float Speed { get; }
    }
}