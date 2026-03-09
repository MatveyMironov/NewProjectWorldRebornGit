namespace WorkforceReserveSystem.Implementations
{
    public class SingletonWorkforceReserveDisplayerSetuperMB : AWorkforceReserveDisplayerSetuperMB
    {
        protected override IWorkforceReserve Reserve { get; } = WorkforceReserveSingleton.Instanace;
    }
}