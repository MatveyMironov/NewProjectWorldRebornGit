using System;

namespace WorkforceReserveSystem
{

    public interface IWorkforceReserve
    {
        public int TotalWorkforce { get; }
        public int AvailableWorkforce { get; }
        public int InvolvedWorkforce { get; }

        public event Action OnTotalWorkforceChanged;
        public event Action OnAvailableWorkforceChanged;
        public event Action OnInvolvedWorkforceChanged;

        public void IncreaseTotalWorkforce(int amount);
        public bool TryDecreaseTotalWorkforce(int amount);
        public bool TryInvolveWorkforce(int amount);
        public bool TryFreeWorkforce(int amount);
    }
}