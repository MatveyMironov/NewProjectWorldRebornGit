using UnityEngine;

namespace BuildingSystem.Testing
{
    [CreateAssetMenu(fileName = "Test Building", menuName = "Building Configuration/Test Building")]
    public class TestBuildingConfigurationSO : ABuildingConfigurationSO
    {
        public override Building CreateBuilding()
        {
            return new(Construction.CreateBuildingStructure(), Info);
        }
    }
}