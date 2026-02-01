namespace BuildingSystem.Implementations
{
    public class SingletonBuildingConfigurationsMannagerDisplayerSetuperMB : ABuildingConfiguratinsManagerDisplayerSetuperMB
    {
        protected override IBuildingConfigurationsManager BuildingConfigurationsManager => BuildingConfigurationsManagerSingleton.Instance;
    }
}