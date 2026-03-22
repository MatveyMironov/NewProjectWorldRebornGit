using ConstructionGridSystem;
using LayoutSystem;
using UnityEngine;

namespace PlacingSystem
{
    public interface IBuildingStructureCreator
    {
        public BuildingStructure CreateBuildingStructure(IConstructionConfiguration constructionConfiguration, Vector2Int cell, EOrientation orientation);
    }
}