namespace BuildingSystem.Testing
{
    public class SingletonBuildingConfigurationsMB : ATestBuildingConfigurationsMB
    {
        private IBuildingConfigurationsManager _buildingConfigurationsManager;
        protected override IBuildingConfigurationsManager BuildingConfigurationsManager => _buildingConfigurationsManager;

        private void Awake()
        {
            _buildingConfigurationsManager = BuildingConfigurationsManagerSingleton.Instance;
        }
    }
}