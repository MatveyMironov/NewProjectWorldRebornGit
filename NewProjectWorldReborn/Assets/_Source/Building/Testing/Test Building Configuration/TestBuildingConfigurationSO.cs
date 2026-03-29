using BuildingInteriorSystem;
using UnityEngine;

namespace BuildingSystem.Testing
{
    [CreateAssetMenu(fileName = "Test Building", menuName = "Building Configuration/Test Building")]
    public class TestBuildingConfigurationSO : ABuildingConfigurationSO
    {
        public override Building CreateBuilding()
        {
            BuildingInterior interior = new(Info.Name, Info.Description);
            return new(this, Construction.CreateBuildingStructure(), Info, interior);
        }
    }
}