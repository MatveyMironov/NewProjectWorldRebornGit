using PlacingSystem;
using ResourceSystem;
using System;
using System.Collections.Generic;

namespace ConstructionResourcesPlacingSystem
{
    public interface IConstructionResourcesPlacingInvokeCreator
    {
        public Action CreateInvoke(IConstructionConfiguration constructionConfiguration, Dictionary<IResourceDefinition, int> constructionResources);
    }
}