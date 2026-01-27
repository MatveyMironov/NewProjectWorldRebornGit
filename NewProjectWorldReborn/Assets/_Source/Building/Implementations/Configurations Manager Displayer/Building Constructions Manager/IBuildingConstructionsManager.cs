using BuildingSystem;

namespace BuildingSystem
{
    public interface IBuildingConstructionsManager
    {
        bool TryAddBuildingConstruction(IBuildingConfiguration configuration);
        bool TryRemoveBuildingConstruction(IBuildingConfiguration configuration);
    }
}