namespace ServiceSystem
{
    public static class ServicesManagerSingleton
    {
        private static IServicesManager _instance;
        public static IServicesManager Instance
        {
            get
            {
                return _instance ??= new ServicesManager();
            }
        }
    }
}