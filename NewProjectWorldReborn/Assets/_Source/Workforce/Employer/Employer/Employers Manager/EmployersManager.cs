using System;
using System.Collections.Generic;
using UnityEngine;

namespace EmployerSystem
{
    public class EmployersManager : IEmployersManager
    {
        private readonly IEmployerWorkforceReserveConnector _workforceReserveConnector;

        public EmployersManager(IEmployerWorkforceReserveConnector workforceReserveConnector)
        {
            _workforceReserveConnector = workforceReserveConnector ?? throw new ArgumentNullException(nameof(workforceReserveConnector));
        }

        private readonly HashSet<IEmployer> _employers = new();

        public HashSet<IEmployer> Employers => new(_employers);
        public event Action<IEmployer> OnEmployerAdded;
        public event Action<IEmployer> OnEmployerRemoved;

        public bool TryAddEmployer(IEmployer employer)
        {
            if (_employers.Add(employer))
            {
                Debug.Log($"Employer {employer} was added");
                _workforceReserveConnector.TryConnectEmployer(employer);
                OnEmployerAdded?.Invoke(employer);
                return true;
            }

            return false;
        }

        public bool TryRemoveEmployer(IEmployer employer)
        {
            if (_employers.Remove(employer))
            {
                Debug.Log($"Employer {employer} was removed");
                _workforceReserveConnector.TryDisconnectEmployer(employer);
                OnEmployerRemoved?.Invoke(employer);
                return true;
            }

            return false;
        }
    }
}