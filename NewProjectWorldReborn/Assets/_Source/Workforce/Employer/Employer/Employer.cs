using System;

namespace EmployerSystem
{
    public class Employer : IEmployer
    {
        private readonly EmployerWorkforce _workforce;

        public Employer(int minWorkForce, int maxWorkForce)
        {
            _workforce = new(minWorkForce, maxWorkForce);
        }

        #region Workforce
        public int MinWorkforce { get => _workforce.MinWorkforce; }
        public int MaxWorkforce { get => _workforce.MaxWorkforce; }
        public int EmployedWorkforce { get => _workforce.EmployedWorkforce; }

        public event Action OnEmployedWorkforceChanged
        {
            add { _workforce.OnEmployedWorkforceChanged += value; }
            remove { _workforce.OnEmployedWorkforceChanged -= value; }
        }
        #endregion

        public event Func<int, bool> OnWorkforceEmploymentRequested;
        public event Func<int, bool> OnWorkforceDismissalRequested;

        public bool TryEmployWorkforce(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));
            
            if (EmployedWorkforce + amount <= _workforce.MaxWorkforce)
            {
                if (OnWorkforceEmploymentRequested?.Invoke(amount) ?? false)
                {
                    _workforce.TryChangeWorkforce(amount);
                }

                return true;
            }

            return false;
        }

        public bool TryDismissWorkforce(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));

            if (EmployedWorkforce - amount >= 0)
            {
                if (OnWorkforceDismissalRequested?.Invoke(amount) ?? false)
                {
                    _workforce.TryChangeWorkforce(-amount);
                }

                return true;
            }

            return false;
        }

        private class EmployerWorkforce
        {
            public int MinWorkforce { get; }
            public int MaxWorkforce { get; }

            public EmployerWorkforce(int minWorkForce, int maxWorkForce)
            {
                MinWorkforce = minWorkForce;
                MaxWorkforce = maxWorkForce;
            }

            private int _employedWorkforce;
            public int EmployedWorkforce
            {
                get { return _employedWorkforce; }
                set
                {
                    _employedWorkforce = value;
                    OnEmployedWorkforceChanged?.Invoke();
                }
            }

            public event Action OnEmployedWorkforceChanged;

            public bool TryChangeWorkforce(int delta)
            {
                if (EmployedWorkforce + delta > MaxWorkforce || EmployedWorkforce + delta < 0)
                { return false; }

                EmployedWorkforce += delta;

                return true;
            }
        }
    }
}