namespace BuildingSystem
{
    public static class ConfigurationBuildingsManagerSingleton
    {
        private static IConfigurationBuildingsManager _instance;
        public static IConfigurationBuildingsManager Instance => _instance ??= new ConfigurationBuildingsManager();
    }
}