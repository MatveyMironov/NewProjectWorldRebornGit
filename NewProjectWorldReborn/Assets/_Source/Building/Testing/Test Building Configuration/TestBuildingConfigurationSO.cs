using ConstructionGridSystem;
using UnityEngine;

namespace BuildingSystem.Testing
{
    [CreateAssetMenu(fileName = "Test Building", menuName = "Building Configuration/Test Building")]
    public class TestBuildingConfigurationSO : ABuildingConfigurationSO
    {
        public override Building CreateBuilding(ConstructedBuilding structure)
        {
            return new(structure, Info);
        }
    }
}