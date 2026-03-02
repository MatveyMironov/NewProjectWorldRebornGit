using CustomInfoSystem;
using System;
using UnityEngine;

namespace ProgressionSystem.Quest.Implementations
{
    public class CompositeRewardInfo : ICustomInfo
    {
        private readonly CompositeReward _reward;
        private readonly CompositeRewardDisplayerMB _displayerPrefab;

        public CompositeRewardInfo(CompositeReward reward, CompositeRewardDisplayerMB displayerPrefab)
        {
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
            _displayerPrefab = displayerPrefab != null ? displayerPrefab : throw new ArgumentNullException(nameof(displayerPrefab));
        }

        public GameObject CreateInfoObject()
        {
            CompositeRewardDisplayerMB displayer = UnityEngine.Object.Instantiate(_displayerPrefab);
            displayer.DisplayReward(_reward);
            return displayer.gameObject;
        }
    }
}