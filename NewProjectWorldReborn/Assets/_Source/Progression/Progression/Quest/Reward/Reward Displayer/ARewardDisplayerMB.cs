using UnityEngine;

namespace ProgressionSystem.Quest
{
    public abstract class ARewardDisplayerMB : MonoBehaviour, IRewardDisplayer
    {
        public abstract void DisplayReward(IReward reward);
        public abstract void Clear();
    }
}