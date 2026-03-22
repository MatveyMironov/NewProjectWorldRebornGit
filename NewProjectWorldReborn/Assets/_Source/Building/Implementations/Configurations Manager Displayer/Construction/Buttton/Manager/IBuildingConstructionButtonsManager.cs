namespace BuildingSystem.Implementations
{
    public interface IBuildingConstructionButtonsManager
    {
        bool TryAddConstructionButton(IBuildingConfiguration configuration);
        bool TryRemoveConstructionButton(IBuildingConfiguration configuration);
    }
}