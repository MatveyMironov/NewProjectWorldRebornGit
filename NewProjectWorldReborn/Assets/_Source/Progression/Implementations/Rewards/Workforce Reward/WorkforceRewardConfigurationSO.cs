using UnityEngine;
using WorkforceReserveSystem;

namespace ProgressionSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Workforce Reward", menuName = "Progression/Reward Configuration/Workforce Reward")]
    public class WorkforceRewardConfigurationSO : ARewardConfigurationSO
    {
        [SerializeField] private int workforceAmount;
        [SerializeField] private WorkforceRewardDisplayerMB displayerPrefab;

        public override IReward CreateReward()
        {
            return new WorkforceReward(WorkforceReserveSingleton.Instanace, workforceAmount, displayerPrefab);
        }
    }
}