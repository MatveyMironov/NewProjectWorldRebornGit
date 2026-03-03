using UnityEngine;

namespace WorkforceReserveSystem.Testing
{
    public class DefaultTestWorkforceReserveButtonsMB : ATestWorkforceReserveButtonsMB
    {
        [SerializeField] private WorkforceReserveMB workforceReserve;

        protected override IWorkforceReserve WorkforceReserve => workforceReserve;
    }
}