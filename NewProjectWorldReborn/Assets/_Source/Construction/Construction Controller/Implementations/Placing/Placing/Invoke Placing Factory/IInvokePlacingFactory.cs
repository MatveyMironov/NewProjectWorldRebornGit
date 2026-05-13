using ConstructionGridSystem;
using System;

namespace PlacingSystem
{
    public interface IInvokePlacingFactory
    {
        Action CreateInvokePlacing(IConstructionConfiguration constructionConfiguration, Action<BuildingStructure> structurePlacedCallback);
    }
}