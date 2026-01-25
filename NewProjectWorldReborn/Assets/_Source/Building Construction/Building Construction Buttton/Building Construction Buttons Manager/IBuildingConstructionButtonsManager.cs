using BuildingSystem;
using ConstructionGridSystem;
using System;

namespace BuildingConstructionUISystem
{
    public interface IBuildingConstructionButtonsManager
    {
        bool TryAddConstructionButton(IBuildingConfiguration configuration, Action<ConstructedBuilding> structureConstructedCallback);
        bool TryRemoveConstructionButton(IBuildingConfiguration configuration);
    }
}