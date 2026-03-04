using CustomInfoSystem;
using System;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class BuildingRewardInfo : ICustomInfo
    {
        private readonly BuildingReward _reward;
        private readonly BuildingRewardDisplayerMB _displayerPrefab;

        public BuildingRewardInfo(BuildingReward reward, BuildingRewardDisplayerMB displayerPrefab)
        {
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
            _displayerPrefab = displayerPrefab != null ? displayerPrefab : throw new ArgumentNullException(nameof(displayerPrefab));
        }

        public GameObject CreateInfoObject()
        {
            BuildingRewardDisplayerMB displayer = UnityEngine.Object.Instantiate(_displayerPrefab);
            displayer.DisplayReward(_reward);
            return displayer.gameObject;
        }
    }
}