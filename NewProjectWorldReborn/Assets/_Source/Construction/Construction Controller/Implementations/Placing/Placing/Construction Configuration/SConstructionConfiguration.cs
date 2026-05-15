using BuildingViewSystem;
using LayoutSystem;
using System;
using UnityEngine;

namespace PlacingSystem
{
    [Serializable]
    public class SConstructionConfiguration : IConstructionConfiguration
    {
        [SerializeField] private Vector2Int[] occupiedCells = new Vector2Int[0];
        [SerializeField] private BuildingViewMB buildingViewPrefab;

        public BuildingViewMB BuildingViewPrefab => buildingViewPrefab;

        public GameObject CreateBuildingPreviewObject()
        {
            return UnityEngine.Object.Instantiate(buildingViewPrefab).gameObject;
        }

        public Layout GetBuildingLayout()
        {
            return new(new(occupiedCells));
        }
    }
}