using BuildingViewSystem;
using ConstructionGridSystem;
using LayoutSystem;
using UnityEngine;

namespace PlacingSystem
{
    public interface IBuildingStructureFactory
    {
        public BuildingStructure CreateBuildingStructure(Vector2Int cell, Layout layout, BuildingViewMB viewPrefab);
    }
}