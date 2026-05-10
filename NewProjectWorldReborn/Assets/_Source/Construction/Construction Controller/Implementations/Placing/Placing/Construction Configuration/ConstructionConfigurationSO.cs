using BuildingViewSystem;
using LayoutSystem;
using System.Collections.Generic;
using UnityEngine;

namespace PlacingSystem
{
    [CreateAssetMenu(fileName = "New Construction Configuration", menuName = "Construction/Construction Configuration")]
    public class ConstructionConfigurationSO : ScriptableObject, IConstructionConfiguration
    {
        [SerializeField] private SConstructionConfiguration constructionConfiguration;

        public BuildingViewMB BuildingViewPrefab => constructionConfiguration.BuildingViewPrefab;

        public GameObject CreateBuildingPreviewObject() => constructionConfiguration.CreateBuildingPreviewObject();
        public Layout GetBuildingLayout() => constructionConfiguration.GetBuildingLayout();
    }
}