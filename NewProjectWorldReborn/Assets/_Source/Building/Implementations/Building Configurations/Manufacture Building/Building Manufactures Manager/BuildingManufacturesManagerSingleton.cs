using ManufactureSystem;

namespace BuildingSystem.Implementations
{
    public static class BuildingManufacturesManagerSingleton
    {
        private static IBuildingManufacturesManager _instance;
        public static IBuildingManufacturesManager Instance => _instance ??= new BuildingManufacturesManager(ManufacturesManagerSingleton.Instance);
    }
}