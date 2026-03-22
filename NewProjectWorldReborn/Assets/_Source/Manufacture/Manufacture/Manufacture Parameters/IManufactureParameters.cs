using ResourceSystem;
using System.Collections.Generic;

namespace ManufactureSystem
{
    public interface IManufactureParameters
    {
        Dictionary<IResourceDefinition, int> ConsumedResources { get; }
        Dictionary<IResourceDefinition, int> ProducedResources { get; }
        float Speed { get; }
    }
}