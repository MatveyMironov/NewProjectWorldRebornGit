using UnityEngine;

namespace BuildingSystem.Testing
{
    public class TestBuildingConfigurationsMB : ATestBuildingConfigurationsMB
    {
        [SerializeField] private BuildingConfigurationsManagerMB buildingConfigurationsManager;
        protected override IBuildingConfigurationsManager BuildingConfigurationsManager => buildingConfigurationsManager;
    }
}