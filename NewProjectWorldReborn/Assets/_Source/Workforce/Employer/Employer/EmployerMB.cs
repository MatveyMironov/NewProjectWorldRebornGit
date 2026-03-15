using System;
using UnityEngine;

namespace EmployerSystem
{
    public class EmployerMB : MonoBehaviour, IEmployer
    {
        [SerializeField] private SEmployerConfiguration employerConfiguration;

        private IEmployer _employer;

        private void Awake()
        {
            _employer = employerConfiguration.GetEmployer();
        }

        public int MinWorkforce => _employer.MinWorkforce;
        public int MaxWorkforce => _employer.MaxWorkforce;
        public int EmployedWorkforce => _employer.EmployedWorkforce;

        public event Action OnEmployedWorkforceChanged
        {
            add { _employer.OnEmployedWorkforceChanged += value; }
            remove { _employer.OnEmployedWorkforceChanged -= value; }
        }

        public event Func<int, bool> OnWorkforceEmploymentRequested
        {
            add { _employer.OnWorkforceEmploymentRequested += value; }
            remove { _employer.OnWorkforceEmploymentRequested -= value; }
        }

        public event Func<int, bool> OnWorkforceDismissalRequested
        {
            add { _employer.OnWorkforceDismissalRequested += value; }
            remove { _employer.OnWorkforceDismissalRequested -= value; }
        }

        public bool TryDismissWorkforce(int amount)
        {
            return _employer.TryDismissWorkforce(amount);
        }

        public bool TryEmployWorkforce(int amount)
        {
            return _employer.TryEmployWorkforce(amount);
        }
    }
}