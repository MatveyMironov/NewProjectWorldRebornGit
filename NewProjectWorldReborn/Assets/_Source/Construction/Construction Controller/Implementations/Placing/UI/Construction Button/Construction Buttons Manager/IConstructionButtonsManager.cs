using ConstructionGridSystem;
using System;
using ConstructionConfigurationSystem;

namespace ConstructionUISystem
{
    public interface IConstructionButtonsManager
    {
        public bool TryAddConstructionButton(IConstructionConfiguration construction, Action<BuildingStructure> buildingPlacedCallback);
        public bool TryRemoveConstructionButton(IConstructionConfiguration construction);
    }
}