using ConstructionGridSystem;
using System;

namespace PlacingSystem
{
    public interface IInvokePlacingFactory
    {
        Action CreatePlacingInvoke(IConstructionConfiguration constructionConfiguration, Action<BuildingStructure> structurePlacedCallback);
    }
}