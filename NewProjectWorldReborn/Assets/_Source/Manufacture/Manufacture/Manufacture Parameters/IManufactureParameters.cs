using ResourceSystem;
using System.Collections.Generic;

namespace ManufactureSystem
{
    internal interface IManufactureParameters
    {
        Dictionary<IResourceDefinition, int> ConsumedResources { get; }
        Dictionary<IResourceDefinition, int> ProducedResources { get; }
        int MinTime { get; }
    }
}