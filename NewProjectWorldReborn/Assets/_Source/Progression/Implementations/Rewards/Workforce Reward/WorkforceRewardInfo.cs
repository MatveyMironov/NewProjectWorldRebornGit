using CustomInfoSystem;
using System;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class WorkforceRewardInfo : ICustomInfo
    {
        private readonly WorkforceReward _reward;
        private readonly WorkforceRewardDisplayerMB _displayerPrefab;

        public WorkforceRewardInfo(WorkforceReward reward, WorkforceRewardDisplayerMB displayerPrefab)
        {
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
            _displayerPrefab = displayerPrefab != null ? displayerPrefab : throw new ArgumentNullException(nameof(displayerPrefab));
        }

        public GameObject CreateInfoObject()
        {
            WorkforceRewardDisplayerMB displayer = UnityEngine.Object.Instantiate(_displayerPrefab);
            displayer.DisplayReward(_reward);
            return displayer.gameObject;
        }
    }
}