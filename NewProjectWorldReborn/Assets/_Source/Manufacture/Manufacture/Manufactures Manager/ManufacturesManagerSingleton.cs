namespace ManufactureSystem
{
    public static class ManufacturesManagerSingleton
    {
        private static IManufacturesManager _instance;
        public static IManufacturesManager Instance
        {
            get
            {
                return _instance ??= new ManufacturesManager(ManufactureControllerSingleton.Instance, ManufactureStorageConnectorSingleton.Instance);
            }
        }
    }
}