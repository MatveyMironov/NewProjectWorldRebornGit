using BuildingInfoSystem;
using BuildingInteriorSystem;
using ConstructionGridSystem;
using PlacingSystem;
using ResourceSystem;
using System.Collections.Generic;
using UnityEngine;

namespace BuildingSystem
{
    [CreateAssetMenu(fileName = "New Building", menuName = "Building Configuration")]
    public class BuildingConfigurationSO : ScriptableObject, IBuildingConfiguration
    {
        [SerializeField] private SBuildingInfo info;
        [SerializeField] private SConstructionConfiguration construction;

        [SerializeField] protected SBuildingInteriorConfiguration interiorConfiguration;

        [Space]
        [SerializeField] private SResourceCountsDictionary constructionResources;

        public IBuildingInfo Info => info;
        public IConstructionConfiguration Construction => construction;

        public Dictionary<IResourceDefinition, int> ConstructionResourcesDictionary => constructionResources.GetResourceCountsDictionary();

        public Building CreateBuilding(BuildingStructure structure)
        {
            BuildingInterior interior = interiorConfiguration.CreateInterior();
            return new(this, structure, Info, interior);
        }
    }
}