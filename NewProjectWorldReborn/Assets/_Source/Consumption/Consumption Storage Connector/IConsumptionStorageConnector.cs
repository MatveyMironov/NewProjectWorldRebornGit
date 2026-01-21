namespace ConsumptionSystem
{
    public interface IConsumptionStorageConnector
    {
        void ConnectConsumption(Consumption consumption);
        void DisconnectConsumption(Consumption consumption);
    }
}