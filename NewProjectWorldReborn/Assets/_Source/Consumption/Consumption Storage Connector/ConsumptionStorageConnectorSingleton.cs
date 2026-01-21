using StorageSystem;

namespace ConsumptionSystem
{
    public static class ConsumptionStorageConnectorSingleton
    {
        private static IConsumptionStorageConnector _instance;
        public static IConsumptionStorageConnector Instance
        {
            get
            {
                return _instance ??= new ConsumptionStorageConnector(StorageSingleton.Instance);
            }
        }
    }
}