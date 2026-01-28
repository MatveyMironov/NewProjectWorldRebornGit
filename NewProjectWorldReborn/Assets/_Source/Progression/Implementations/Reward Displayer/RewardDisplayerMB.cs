using CustomInfoSystem;
using UnityEngine;

namespace ProgressionSystem.Quest.Implementations
{
    public class RewardDisplayerMB : ARewardDisplayerMB
    {
        [SerializeField] private CustomInfoDisplayerMB infoDisplayer;

        public override void DisplayReward(IReward reward)
        {
            infoDisplayer.DisplayInfo(reward.Info);
        }

        public override void Clear()
        {
            infoDisplayer.Clear();
        }
    }
}