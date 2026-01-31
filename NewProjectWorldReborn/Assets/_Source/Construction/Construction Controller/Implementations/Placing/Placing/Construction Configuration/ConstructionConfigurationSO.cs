using ConstructionGridSystem;
using System.Collections.Generic;
using UnityEngine;

namespace PlacingSystem
{
    [CreateAssetMenu(fileName = "New Construction Configuration", menuName = "Construction/Construction Configuration")]
    public class ConstructionConfigurationSO : ScriptableObject, IConstructionConfiguration
    {
        [SerializeField] private SConstructionConfiguration constructionConfiguration;

        public HashSet<Vector2Int> OccupiedCells => constructionConfiguration.OccupiedCells;
        public ConstructionPreviewMB ConstructionPreviewPrefab => constructionConfiguration.ConstructionPreviewPrefab;

        public BuildingStructure CreateBuildingStructure()
        {
            return constructionConfiguration.CreateBuildingStructure();
        }
    }
}