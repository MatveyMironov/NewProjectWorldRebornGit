namespace ConsumptionSystem
{
    public static class ConsumptionsManagerSingleton
    {
        private static IConsumptionsManager _instance;
        public static IConsumptionsManager Instance
        {
            get
            {
                return _instance ??= new ConsumptionsManager(ConsumptionControllerSingleton.Instance, ConsumptionStorageConnectorSingleton.Instance);
            }
        }
    }
}