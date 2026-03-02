using System;

namespace BuildingSystem
{
    public interface IConfigurationBuildingsManager
    {
        event Action<Building> OnBuildingAdded;
        event Action<Building> OnBuildingRemoved;

        bool TryAddBuilding(Building building);
        bool TryRemoveBuilding(Building building);
        int GetBuildingCount(IBuildingConfiguration configuration);
    }
}