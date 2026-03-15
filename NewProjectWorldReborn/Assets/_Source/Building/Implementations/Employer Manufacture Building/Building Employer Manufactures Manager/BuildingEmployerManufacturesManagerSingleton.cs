namespace BuildingSystem.Implementations
{
    public static class BuildingEmployerManufacturesManagerSingleton
    {
        private static IBuildingEmployerManufacturesManager _instance;
        public static IBuildingEmployerManufacturesManager Instance => 
            _instance ??= new BuildingEmployerManufacturesManager(BuildingEmployersManagerSingleton.Instance, BuildingManufacturesManagerSingleton.Instance);
    }
}