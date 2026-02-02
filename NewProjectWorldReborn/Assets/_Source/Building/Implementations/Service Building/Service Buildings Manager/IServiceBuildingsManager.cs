using ServiceSystem;

namespace BuildingSystem.Implementations
{
    public interface IServiceBuildingsManager
    {
        bool TryAddServiceBuilding(Building building, ServiceProvider serviceProvider);
        bool TryRemoveServiceBuilding(Building building);
    }
}