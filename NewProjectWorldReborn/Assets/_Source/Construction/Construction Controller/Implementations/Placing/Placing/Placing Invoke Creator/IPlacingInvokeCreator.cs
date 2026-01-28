using System;

namespace PlacingSystem
{
    public interface IPlacingInvokeCreator
    {
        public Action CreatePlacingInvoke(IConstructionConfiguration constructionConfiguration);
    }
}