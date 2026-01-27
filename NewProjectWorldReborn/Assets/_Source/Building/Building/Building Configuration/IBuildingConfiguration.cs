using BuildingInfoSystem;
using ConstructionConfigurationSystem;
using ConstructionGridSystem;

namespace BuildingSystem
{
    public interface IBuildingConfiguration
    {
        IConstructionConfiguration Construction { get; }
        IBuildingInfo Info { get; }

        Building CreateBuilding(ConstructedBuilding structure);
    }
}