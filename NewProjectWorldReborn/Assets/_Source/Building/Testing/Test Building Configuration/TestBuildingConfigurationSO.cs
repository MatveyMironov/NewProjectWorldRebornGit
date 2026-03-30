using BuildingInteriorSystem;
using UnityEngine;

namespace BuildingSystem.Testing
{
    [CreateAssetMenu(fileName = "Test Building", menuName = "Building Configuration/Test Building")]
    public class TestBuildingConfigurationSO : ABuildingConfigurationSO
    {
        [SerializeField] private SBuildingInteriorConfiguration interiorConfiguration;
        public override Building CreateBuilding()
        {
            BuildingInterior interior = interiorConfiguration.CreateInterior();
            return new(this, Construction.CreateBuildingStructure(), Info, interior);
        }
    }
}