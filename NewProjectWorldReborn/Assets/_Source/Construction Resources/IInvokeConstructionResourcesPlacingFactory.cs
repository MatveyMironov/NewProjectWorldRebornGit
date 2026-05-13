using ConstructionGridSystem;
using PlacingSystem;
using ResourceSystem;
using System;
using System.Collections.Generic;

namespace ConstructionResourcesSystem
{
    public interface IInvokeConstructionResourcesPlacingFactory
    {
        Action CreateInvokePlacing(IConstructionConfiguration constructionConfiguration, Action<BuildingStructure> structurePlacedCallback, Dictionary<IResourceDefinition, int> requiredResourcesDictionary);
    }
}