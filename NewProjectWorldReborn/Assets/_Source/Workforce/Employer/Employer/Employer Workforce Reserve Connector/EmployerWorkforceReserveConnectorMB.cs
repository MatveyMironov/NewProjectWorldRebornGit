using UnityEngine;
using WorkforceReserveSystem;

namespace EmployerSystem
{
    public class EmployerWorkforceReserveConnectorMB : MonoBehaviour, IEmployerWorkforceReserveConnector
    {
        [SerializeField] private WorkforceReserveMB workforceReserve;

        private IEmployerWorkforceReserveConnector _employerWorkforceReserveConnector;

        private void Awake()
        {
            _employerWorkforceReserveConnector = new EmployerWorkforceReserveConnector(workforceReserve);
        }

        public bool TryConnectEmployer(IEmployer employer)
        {
            return _employerWorkforceReserveConnector.TryConnectEmployer(employer);
        }

        public bool TryDisconnectEmployer(IEmployer employer)
        {
            return _employerWorkforceReserveConnector.TryDisconnectEmployer(employer);
        }
    }
}