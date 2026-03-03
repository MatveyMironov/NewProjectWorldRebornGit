using System;
using System.Collections.Generic;
using UnityEngine;

namespace EmployerSystem
{
    public class EmployersManagerMB : MonoBehaviour, IEmployersManager
    {
        [SerializeField] private EmployerWorkforceReserveConnectorMB workforceReserveConnector;

        private IEmployersManager _employersManager;

        public HashSet<IEmployer> Employers => _employersManager.Employers;

        public event Action<IEmployer> OnEmployerAdded
        {
            add => _employersManager.OnEmployerAdded += value;
            remove => _employersManager.OnEmployerAdded -= value;
        }

        public event Action<IEmployer> OnEmployerRemoved
        {
            add => _employersManager.OnEmployerRemoved += value;
            remove => _employersManager.OnEmployerRemoved -= value;
        }

        private void Awake()
        {
            _employersManager = new EmployersManager(workforceReserveConnector);
        }

        public bool TryAddEmployer(IEmployer employer)
        {
            return _employersManager.TryAddEmployer(employer);
        }

        public bool TryRemoveEmployer(IEmployer employer)
        {
            return _employersManager.TryRemoveEmployer(employer);
        }
    }
}