using BuildingInfoSystem;
using PlacingSystem;
using ResourceSystem;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    public abstract class ABuildingConfigurationSO : ScriptableObject, IBuildingConfiguration
    {
        [SerializeField] private SBuildingInfo info;
        [SerializeField] private SConstructionConfiguration construction;
        [SerializeField] private SResourceCountsDictionary constructionResources;

        protected IConstructionConfiguration Construction => construction;

        public IBuildingInfo Info => info;
        public HashSet<Vector2Int> OccupiedCells => construction.OccupiedCells;
        public ConstructionPreviewMB ConstructionPreviewPrefab => construction.ConstructionPreviewPrefab;

        public Dictionary<IResourceDefinition, int> ConstructionResources => constructionResources.GetResourceCountsDictionary();

        public abstract Building CreateBuilding();
    }
}