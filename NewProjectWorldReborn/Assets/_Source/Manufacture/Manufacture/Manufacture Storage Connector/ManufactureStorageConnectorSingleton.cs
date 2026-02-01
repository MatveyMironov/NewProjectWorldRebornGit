using StorageSystem;

namespace ManufactureSystem
{
    public class ManufactureStorageConnectorSingleton
    {
        private static IManufactureStorageConnector _instance;
        public static IManufactureStorageConnector Instance => _instance ??= new ManufactureStorageConnector(StorageSingleton.Instance);
    }
}