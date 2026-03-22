using System;

namespace EmployerSystem
{
    public interface IEmployer
    {
        #region Workforce
        public int MinWorkforce { get; }
        public int MaxWorkforce { get; }
        public int EmployedWorkforce { get; }

        public event Action OnEmployedWorkforceChanged;
        #endregion

        public event Func<int, bool> OnWorkforceEmploymentRequested;
        public event Func<int, bool> OnWorkforceDismissalRequested;

        public bool TryEmployWorkforce(int amount);
        public bool TryDismissWorkforce(int amount);
    }
}