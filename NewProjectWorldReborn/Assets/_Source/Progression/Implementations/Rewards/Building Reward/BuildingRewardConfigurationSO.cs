using BuildingSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    [CreateAssetMenu(fileName = "New Building Reward", menuName = "Progression/Reward Configuration/Building Reward")]
    public class BuildingRewardConfigurationSO : ARewardConfigurationSO
    {
        [SerializeField] private BuildingConfigurationSO building;
        [SerializeField] private BuildingRewardDisplayerMB displayerPrefab;

        public override IReward CreateReward()
        {
            return new BuildingReward(building, displayerPrefab, BuildingConfigurationsManagerSingleton.Instance);
        }
    }
}