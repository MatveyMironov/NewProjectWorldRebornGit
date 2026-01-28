using BuildingViewSystem;
using PlacingSystem;
using System.Collections.Generic;
using UnityEngine;

namespace PlacingSystem
{
    public interface IConstructionConfiguration
    {
        HashSet<Vector2Int> OccupiedCells { get; }
        ConstructionPreviewMB ConstructionPreviewPrefab { get; }

        BuildingViewMB SpawnBuildingView();
    }
}