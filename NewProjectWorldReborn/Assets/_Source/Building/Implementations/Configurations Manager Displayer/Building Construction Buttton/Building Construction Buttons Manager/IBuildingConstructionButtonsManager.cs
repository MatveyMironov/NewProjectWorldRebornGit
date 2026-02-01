using BuildingSystem;

namespace BuildingConstructionUISystem
{
    public interface IBuildingConstructionButtonsManager
    {
        bool TryAddConstructionButton(IBuildingConfiguration configuration);
        bool TryRemoveConstructionButton(IBuildingConfiguration configuration);
    }
}