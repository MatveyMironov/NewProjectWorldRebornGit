using BuildingInfoSystem;
using ConstructionGridSystem;
using PlacingSystem;

namespace BuildingSystem
{
    public interface IBuildingConfiguration
    {
        IConstructionConfiguration Construction { get; }
        IBuildingInfo Info { get; }

        Building CreateBuilding(BuildingStructure structure);
    }
}