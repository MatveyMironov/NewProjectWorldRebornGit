using ManufactureSystem;

namespace BuildingSystem.Implementations
{
    public interface IBuildingManufacturesManager
    {
        bool TryAddBuildingManufacture(Building building, IManufacture manufacture);
        bool TryRemoveBuildingManufacture(Building building);
    }
}