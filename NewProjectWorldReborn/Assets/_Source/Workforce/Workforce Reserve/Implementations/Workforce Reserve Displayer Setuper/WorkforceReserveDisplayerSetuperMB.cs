using UnityEngine;

namespace WorkforceReserveSystem.Implementations
{
    public class WorkforceReserveDisplayerSetuperMB : AWorkforceReserveDisplayerSetuperMB
    {
        [SerializeField] private WorkforceReserveMB workforceReserve;

        protected override IWorkforceReserve Reserve => workforceReserve;
    }
}