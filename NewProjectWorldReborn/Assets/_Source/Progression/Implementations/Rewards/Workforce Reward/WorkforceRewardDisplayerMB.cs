using CustomUISystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class WorkforceRewardDisplayerMB : MonoBehaviour
    {
        [SerializeField] private ANumberDisplayerMB workforceAmountDisplayer;

        public void DisplayReward(WorkforceReward reward)
        {
            workforceAmountDisplayer.DisplayNumber(reward.WorkforceAmount);
        }

        public void Clear()
        {
            workforceAmountDisplayer.DisplayNumber(0);
        }
    }
}