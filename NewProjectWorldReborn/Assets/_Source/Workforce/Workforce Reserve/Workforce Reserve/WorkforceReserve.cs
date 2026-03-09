using System;

namespace WorkforceReserveSystem
{
    public class WorkforceReserve : IWorkforceReserve
    {
        #region Total Workforce
        private int _totalWorkforce;
        public int TotalWorkforce
        {
            get { return _totalWorkforce; }
            set
            {
                _totalWorkforce = value;
                OnTotalWorkforceChanged?.Invoke();
            }
        }

        public event Action OnTotalWorkforceChanged;
        #endregion

        #region Available Workforce
        private int _availableWorkforce;
        public int AvailableWorkforce
        {
            get { return _availableWorkforce; }
            set
            {
                _availableWorkforce = value;
                OnAvailableWorkforceChanged?.Invoke();
            }
        }

        public event Action OnAvailableWorkforceChanged;
        #endregion

        #region Involved Workforce
        private int _involvedWorkforce;
        public int InvolvedWorkforce
        {
            get { return _involvedWorkforce; }
            set
            {
                _involvedWorkforce = value;
                OnInvolvedWorkforceChanged?.Invoke();
            }
        }

        public event Action OnInvolvedWorkforceChanged;
        #endregion

        public void IncreaseTotalWorkforce(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));

            TotalWorkforce += amount;
            AvailableWorkforce += amount;
        }

        public bool TryDecreaseTotalWorkforce(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));

            if (TotalWorkforce < amount || AvailableWorkforce < amount)
            { return false; }

            TotalWorkforce -= amount;
            AvailableWorkforce -= amount;

            return true;
        }

        public bool TryInvolveWorkforce(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));

            if (AvailableWorkforce < amount)
            { return false; }

            AvailableWorkforce -= amount;
            InvolvedWorkforce += amount;

            return true;
        }

        public bool TryFreeWorkforce(int amount)
        {
            if (amount < 0) throw new ArgumentOutOfRangeException(nameof(amount));

            if (InvolvedWorkforce < amount)
            { return false; }

            InvolvedWorkforce -= amount;
            AvailableWorkforce += amount;

            return true;
        }
    }
}