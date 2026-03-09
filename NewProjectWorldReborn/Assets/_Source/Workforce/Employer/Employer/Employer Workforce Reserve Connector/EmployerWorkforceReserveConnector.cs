using System;
using WorkforceReserveSystem;

namespace EmployerSystem
{
    public class EmployerWorkforceReserveConnector : IEmployerWorkforceReserveConnector
    {
        private readonly IWorkforceReserve _workforceReserve;

        public EmployerWorkforceReserveConnector(IWorkforceReserve workforceReserve)
        {
            _workforceReserve = workforceReserve ?? throw new ArgumentNullException(nameof(workforceReserve));
        }

        public bool TryConnectEmployer(IEmployer employer)
        {
            employer.OnWorkforceEmploymentRequested += TryInvolveWorkforceFromReserve;
            employer.OnWorkforceDismissalRequested += TryReturnWorkforceToReserve;
            return true;
        }

        public bool TryDisconnectEmployer(IEmployer employer)
        {
            if (employer.TryDismissWorkforce(employer.EmployedWorkforce))
            {
                employer.OnWorkforceEmploymentRequested -= TryInvolveWorkforceFromReserve;
                employer.OnWorkforceDismissalRequested -= TryReturnWorkforceToReserve;
                return true;
            }

            return false;
        }

        private bool TryInvolveWorkforceFromReserve(int amount)
        {
            return _workforceReserve.TryInvolveWorkforce(amount);
        }

        private bool TryReturnWorkforceToReserve(int amount)
        {
            return _workforceReserve.TryFreeWorkforce(amount);
        }
    }
}