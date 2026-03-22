using UnityEngine;

namespace ProgressionSystem
{
    public abstract class ARewardConfigurationSO : ScriptableObject, IRewardConfiguration
    {
        public abstract IReward CreateReward();
    }
}