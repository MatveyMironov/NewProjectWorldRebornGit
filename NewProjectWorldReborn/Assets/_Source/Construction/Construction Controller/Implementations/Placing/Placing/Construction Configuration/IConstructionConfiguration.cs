using BuildingViewSystem;
using ConstructionPreviewSystem;
using System.Collections.Generic;
using UnityEngine;

namespace ConstructionConfigurationSystem
{
    public interface IConstructionConfiguration
    {
        HashSet<Vector2Int> OccupiedCells { get; }
        ConstructionPreviewMB ConstructionPreviewPrefab { get; }
        BuildingViewMB BuildingViewPrefab { get; }
    }
}