using CustomInfoSystem;
using System;
using WorkforceReserveSystem;

namespace ProgressionSystem.Implementations
{
    public class WorkforceReward : IReward
    {
        private readonly IWorkforceReserve _workforceReserve;

        public WorkforceReward(IWorkforceReserve workforceReserve, int workforceAmount, WorkforceRewardDisplayerMB displayerPrefab)
        {
            _workforceReserve = workforceReserve ?? throw new ArgumentNullException(nameof(workforceReserve));
            WorkforceAmount = workforceAmount < 0 ? throw new ArgumentOutOfRangeException("Rewarded workforce amount can't be negative!") : workforceAmount;

            Info = new WorkforceRewardInfo(this, displayerPrefab);
        }

        public int WorkforceAmount { get; }

        public ICustomInfo Info { get; }

        public void Reward()
        {
            _workforceReserve.IncreaseTotalWorkforce(WorkforceAmount);
        }
    }
}