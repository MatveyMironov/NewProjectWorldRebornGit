using ConstructionGridSystem;
using System;
using ConstructionConfigurationSystem;

namespace PlacingSystem
{
    public interface IPlacingInvokeCreator
    {
        public Action CreatePlacingInvoke(IConstructionConfiguration constructionConfiguration, Action<BuildingStructure> buildingPlacedCallback);
    }
}
