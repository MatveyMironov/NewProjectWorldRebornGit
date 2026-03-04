using EmployerSystem;
using System;

namespace EfficiencySystem.Implementations
{
    public class EmployerEfficiency : IEfficiency
    {
        private readonly IEmployer _employer;

        public EmployerEfficiency(IEmployer employer)
        {
            _employer = employer ?? throw new ArgumentNullException(nameof(employer));
        }

        public float Efficiency => (float)_employer.EmployedWorkforce / _employer.MaxWorkforce;

        public event Action OnEfficiencyChanged
        {
            add => _employer.OnEmployedWorkforceChanged += value;
            remove => _employer.OnEmployedWorkforceChanged -= value;
        }
    }
}