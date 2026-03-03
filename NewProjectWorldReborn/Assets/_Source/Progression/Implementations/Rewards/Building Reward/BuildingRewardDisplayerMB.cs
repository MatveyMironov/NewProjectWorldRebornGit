using BuildingSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class BuildingRewardDisplayerMB : MonoBehaviour
    {
        [SerializeField] private ABuildingConfigurationDisplayerMB _buildingConfigurationDisplayer;

        public void DisplayReward(BuildingReward reward)
        {
            _buildingConfigurationDisplayer.DisplayBuildingConiguration(reward.Building);
        }

        public void Clear()
        {
            _buildingConfigurationDisplayer.Clear();
        }
    }
}