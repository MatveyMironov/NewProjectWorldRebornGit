using BuildingInfoSystem;
using PlacingSystem;
using ResourceSystem;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public interface IBuildingConfiguration
    {
        IBuildingInfo Info { get; }
        HashSet<Vector2Int> OccupiedCells { get; }
        ConstructionPreviewMB ConstructionPreviewPrefab { get; }

        Dictionary<IResourceDefinition, int> ConstructionResources { get; }

        Building CreateBuilding();
    }
}