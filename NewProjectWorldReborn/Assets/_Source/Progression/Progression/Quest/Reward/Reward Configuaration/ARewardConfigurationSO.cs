using UnityEngine;

namespace ProgressionSystem.Quest
{
    public abstract class ARewardConfigurationSO : ScriptableObject, IRewardConfiguration
    {
        public abstract IReward CreateReward();
    }
}