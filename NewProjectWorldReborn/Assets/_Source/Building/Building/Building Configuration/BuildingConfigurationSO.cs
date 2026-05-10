using BuildingInfoSystem;
using BuildingInteriorSystem;
using ConstructionGridSystem;
using PlacingSystem;
using UnityEngine;

namespace BuildingSystem
{
    [CreateAssetMenu(fileName = "New Building", menuName = "Building Configuration")]
    public class BuildingConfigurationSO : ScriptableObject, IBuildingConfiguration
    {
        [SerializeField] private SBuildingInfo info;
        [SerializeField] private SConstructionConfiguration construction;

        [SerializeField] protected SBuildingInteriorConfiguration interiorConfiguration;

        public IBuildingInfo Info => info;
        public IConstructionConfiguration Construction => construction;

        public Building CreateBuilding(BuildingStructure structure)
        {
            BuildingInterior interior = interiorConfiguration.CreateInterior();
            return new(this, structure, Info, interior);
        }
    }
}