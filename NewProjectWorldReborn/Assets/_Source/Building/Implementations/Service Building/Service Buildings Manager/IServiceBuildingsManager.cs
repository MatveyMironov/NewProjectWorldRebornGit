using ServiceSystem;
using System;

namespace BuildingSystem.Implementations
{
    public interface IServiceBuildingsManager
    {
        Building[] Buildings { get; }

        event Action<Building> OnBuildingAdded;
        event Action<Building> OnBuildingRemoved;

        bool TryAddServiceBuilding(Building building, ServiceProvider serviceProvider);
        bool TryRemoveServiceBuilding(Building building);
        bool TryGetBuildingServiceProvider(Building building, out ServiceProvider serviceProvider);
    }
}