using BuildingViewSystem;
using LayoutSystem;
using UnityEngine;

namespace PlacingSystem
{
    public interface IBuildingViewInstantiator
    {
        public BuildingViewMB InstantiateBuildingView(BuildingViewMB prefab, Vector2Int cell, EOrientation orientation);
    }
}
