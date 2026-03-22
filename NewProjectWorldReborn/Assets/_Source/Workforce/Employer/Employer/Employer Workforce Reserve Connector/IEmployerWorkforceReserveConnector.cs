namespace EmployerSystem
{
    public interface IEmployerWorkforceReserveConnector
    {
        public bool TryConnectEmployer(IEmployer employer);
        public bool TryDisconnectEmployer(IEmployer employer);
    }
}