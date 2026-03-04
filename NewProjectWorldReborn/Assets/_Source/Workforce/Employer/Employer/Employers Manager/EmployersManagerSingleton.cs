namespace EmployerSystem
{
    public static class EmployersManagerSingleton
    {
        private static IEmployersManager _instance;
        public static IEmployersManager Instance
        {
            get
            {
                return _instance ??= new EmployersManager(EmployerWorkforceReserveConnectorSingleton.Instance);
            }
        }
    }
}