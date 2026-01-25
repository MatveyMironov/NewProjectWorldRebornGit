using ConstructionGridSystem;
using System;
using ConstructionConfigurationSystem;

namespace ConstructionUISystem
{
    public interface IConstructionButtonsManager
    {
        public bool TryAddConstructionButton(IConstructionConfiguration construction, Action<ConstructedBuilding> buildingPlacedCallback);
        public bool TryRemoveConstructionButton(IConstructionConfiguration construction);
    }
}