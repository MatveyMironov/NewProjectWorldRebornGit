using BuildingInfoSystem;
using ConstructionGridSystem;
using PlacingSystem;

namespace BuildingSystem
{
    public interface IBuildingConfiguration
    {
        IBuildingInfo Info { get; }
        IConstructionConfiguration Construction { get; }

        Building CreateBuilding(BuildingStructure structure);
    }
}