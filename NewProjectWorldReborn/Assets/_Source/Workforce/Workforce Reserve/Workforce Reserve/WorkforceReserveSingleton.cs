namespace WorkforceReserveSystem
{
    public static class WorkforceReserveSingleton
    {
        private static IWorkforceReserve _instance;
        public static IWorkforceReserve Instanace
        {
            get
            {
                _instance ??= new WorkforceReserve();

                return _instance;
            }
        }
    }
}