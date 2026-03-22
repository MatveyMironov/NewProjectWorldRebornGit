using EmployerSystem;

namespace BuildingSystem.Implementations
{
    public static class BuildingEmployersManagerSingleton
    {
        private static IBuildingEmployersManager _instance;
        public static IBuildingEmployersManager Instance => _instance ??= new BuildingEmployersManager(EmployersManagerSingleton.Instance);
    }
}