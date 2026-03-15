namespace WorkforceReserveSystem.Testing
{
    public class SingletonTestWorkforceReserveButtonsMB : ATestWorkforceReserveButtonsMB
    {
        protected override IWorkforceReserve WorkforceReserve { get; } = WorkforceReserveSingleton.Instanace;
    }
}