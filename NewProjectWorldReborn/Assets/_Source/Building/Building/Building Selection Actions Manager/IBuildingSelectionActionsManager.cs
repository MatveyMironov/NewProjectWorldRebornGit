using System;

namespace BuildingSystem
{
    public interface IBuildingSelectionActionsManager
    {
        bool TryAddBuildingSelectionAction(Building building);
        bool TryRemoveBuildingSelectionAction(Building building);
        bool TryGetBuildingSelectionAction(Building building, out Action selectBuilding);
    }
}