namespace ManufactureSystem
{
    public interface IManufactureStorageConnector
    {
        void ConnectManufacture(IManufacture manufacture);
        void DisconnectManufacture(IManufacture manufacture);
    }
}