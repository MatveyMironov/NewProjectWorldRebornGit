namespace BuildingSystem
{
    public static class BuildingConfigurationsManagerSingleton
    {
        private static IBuildingConfigurationsManager _instance;
        public static IBuildingConfigurationsManager Instance
        {
            get
            {
                return _instance ??= new BuildingConfigurationsManager();
            }
        }
    }
}