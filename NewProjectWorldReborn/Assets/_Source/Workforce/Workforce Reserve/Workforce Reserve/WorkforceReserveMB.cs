using System;
using UnityEngine;

namespace WorkforceReserveSystem
{
    public class WorkforceReserveMB : MonoBehaviour, IWorkforceReserve
    {
        private IWorkforceReserve _workforceReserve;

        private void Awake()
        {
            _workforceReserve = new WorkforceReserve();
        }

        public int TotalWorkforce => _workforceReserve.TotalWorkforce;
        public event Action OnTotalWorkforceChanged
        {
            add { _workforceReserve.OnTotalWorkforceChanged += value; }
            remove { _workforceReserve.OnTotalWorkforceChanged -= value; }
        }

        public int AvailableWorkforce => _workforceReserve.AvailableWorkforce;
        public event Action OnAvailableWorkforceChanged
        {
            add { _workforceReserve.OnAvailableWorkforceChanged += value; }
            remove { _workforceReserve.OnAvailableWorkforceChanged -= value; }
        }

        public int InvolvedWorkforce => _workforceReserve.InvolvedWorkforce;
        public event Action OnInvolvedWorkforceChanged
        {
            add { _workforceReserve.OnInvolvedWorkforceChanged += value; }
            remove { _workforceReserve.OnInvolvedWorkforceChanged -= value; }
        }

        public void IncreaseTotalWorkforce(int amount)
        {
            _workforceReserve.IncreaseTotalWorkforce(amount);
        }

        public bool TryDecreaseTotalWorkforce(int amount)
        {
            return _workforceReserve.TryDecreaseTotalWorkforce(amount);
        }

        public bool TryInvolveWorkforce(int amount)
        {
            return _workforceReserve.TryInvolveWorkforce(amount);
        }

        public bool TryFreeWorkforce(int amount)
        {
            return _workforceReserve.TryFreeWorkforce(amount);
        }
    }
}