namespace ServiceSystem
{
    public static class ServiceProvidersManagerSingleton
    {
        private static IServiceProvidersManager _instance;
        public static IServiceProvidersManager Instance
        {
            get
            {
                return _instance ??= new ServiceProvidersManager(ServicesManagerSingleton.Instance);
            }
        }
    }
}