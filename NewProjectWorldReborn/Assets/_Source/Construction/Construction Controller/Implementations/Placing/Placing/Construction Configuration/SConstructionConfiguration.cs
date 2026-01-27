using BuildingViewSystem;
using ConstructionPreviewSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ConstructionConfigurationSystem
{
    [Serializable]
    public class SConstructionConfiguration : IConstructionConfiguration
    {
        [SerializeField] private ConstructionPreviewMB constructionPreviewPrefab;
        [SerializeField] private BuildingViewMB buildingViewPrefab;
        [SerializeField] private Vector2Int[] occupiedCells = new Vector2Int[0];

        public HashSet<Vector2Int> OccupiedCells { get => occupiedCells.ToHashSet(); }
        public ConstructionPreviewMB ConstructionPreviewPrefab { get => constructionPreviewPrefab; }
        public BuildingViewMB BuildingViewPrefab { get => buildingViewPrefab; }
    }
}
