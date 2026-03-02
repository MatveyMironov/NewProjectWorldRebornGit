namespace BuildingSystem.Implementations
{
    public class SingletonConfigurationBuildingsManagerSetuperMB : AConfigurationBuildingsManagerSetuperMB
    {
        protected override IConfigurationBuildingsManager ConfigurationBuildingsManager { get; } = ConfigurationBuildingsManagerSingleton.Instance;
        protected override IStructureBuildingsManager StructureBuildingsManager { get; } = StructureBuildingsManagerSingleton.Instance;
    }
}