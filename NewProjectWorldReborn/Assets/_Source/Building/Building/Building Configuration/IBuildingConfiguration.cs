using BuildingInfoSystem;
using ConstructionGridSystem;
using PlacingSystem;
using ResourceSystem;
using System.Collections.Generic;

namespace BuildingSystem
{
    public interface IBuildingConfiguration
    {
        IBuildingInfo Info { get; }
        IConstructionConfiguration Construction { get; }
        Dictionary<IResourceDefinition, int> ConstructionResourcesDictionary { get; }

        Building CreateBuilding(BuildingStructure structure);
    }
}