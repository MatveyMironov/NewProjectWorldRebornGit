namespace BuildingSystem.Implementations
{
    public interface IBuildingConstructionsManager
    {
        bool TryAddBuildingConstruction(IBuildingConfiguration configuration);
        bool TryRemoveBuildingConstruction(IBuildingConfiguration configuration);
    }
}