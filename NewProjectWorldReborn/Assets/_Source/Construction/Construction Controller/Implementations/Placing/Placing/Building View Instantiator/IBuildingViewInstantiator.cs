using BuildingViewSystem;
using LayoutSystem;
using UnityEngine;

namespace PlacingSystem
{
    public interface IBuildingViewInstantiator
    {
        public BuildingViewMB InstantiateBuildingView(IConstructionConfiguration constructionConfiguration, Vector2Int cell, EOrientation orientation);
    }
}