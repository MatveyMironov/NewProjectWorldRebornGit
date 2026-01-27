namespace BuildingSystem.Implementations
{
    public class SingletonBuildingConfigurationsMannagerDisplayerSetuper : ABuildingConfiguratinsManagerDisplayerSetuper
    {
        protected override IBuildingConfigurationsManager BuildingConfigurationsManager => BuildingConfigurationsManagerSingleton.Instance;
    }
}