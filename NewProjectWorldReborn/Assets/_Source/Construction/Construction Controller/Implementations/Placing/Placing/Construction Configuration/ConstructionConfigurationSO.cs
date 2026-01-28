using BuildingViewSystem;
using PlacingSystem;
using System.Collections.Generic;
using UnityEngine;

namespace PlacingSystem
{
    [CreateAssetMenu(fileName = "New Construction Configuration", menuName = "Construction/Construction Configuration")]
    public class ConstructionConfigurationSO : ScriptableObject, IConstructionConfiguration
    {
        [SerializeField] private SConstructionConfiguration constructionConfiguration;

        public HashSet<Vector2Int> OccupiedCells => ((IConstructionConfiguration)constructionConfiguration).OccupiedCells;
        public ConstructionPreviewMB ConstructionPreviewPrefab => ((IConstructionConfiguration)constructionConfiguration).ConstructionPreviewPrefab;

        public BuildingViewMB SpawnBuildingView()
        {
            return constructionConfiguration.SpawnBuildingView();
        }
    }
}