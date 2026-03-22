using ServiceSystem;

namespace BuildingSystem.Implementations
{
    public static class ServiceBuildingsManagerSingleton
    {
        private static IServiceBuildingsManager _instance;
        public static IServiceBuildingsManager Instance => _instance ??= new ServiceBuildingsManager(ServiceProvidersManagerSingleton.Instance);
    }
}