using ConstructionGridSystem;
using PlacingSystem;
using System;

namespace ConstructionUISystem
{
    public interface IConstructionButtonsManager
    {
        public bool TryAddConstructionButton(IConstructionConfiguration construction, Action<BuildingStructure> structurePlacedCallback);
        public bool TryRemoveConstructionButton(IConstructionConfiguration construction);
    }
}