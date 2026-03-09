using WorkforceReserveSystem;

namespace EmployerSystem
{
    public static class EmployerWorkforceReserveConnectorSingleton
    {
        private static IEmployerWorkforceReserveConnector _instance;
        public static IEmployerWorkforceReserveConnector Instance
        {
            get
            {
                return _instance ??= new EmployerWorkforceReserveConnector(WorkforceReserveSingleton.Instanace);
            }
        }
    }
}