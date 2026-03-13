using System;

namespace BuildingSystem
{
    public interface IBuildingInteractionsManager
    {
        bool TryAddBuildingInteraction(Building building);
        bool TryRemoveBuildingInteraction(Building building);
        bool TryGetBuildingInteraction(Building building, out Action interaction);
    }
}