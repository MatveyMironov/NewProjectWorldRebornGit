using ManufactureSystem;
using System;

namespace BuildingSystem.Implementations
{
    public interface IBuildingManufacturesManager
    {
        Building[] Buildings { get; }

        event Action<Building> OnBuildingAdded;
        event Action<Building> OnBuildingRemoved;

        bool TryAddBuildingManufacture(Building building, IManufacture manufacture);
        bool TryRemoveBuildingManufacture(Building building);
        bool TryGetBuildingManufacture(Building building, out IManufacture manufacture);
    }
}