namespace StorageSystem
{
    public static class StorageSingleton
    {
        private static IStorage _instance;
        public static IStorage Instance
        {
            get
            {
                return _instance ??= new Storage();
            }
        }
    }
}