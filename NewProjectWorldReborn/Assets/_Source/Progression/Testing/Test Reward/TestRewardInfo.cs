using CustomInfoSystem;
using System;
using UnityEngine;

namespace ProgressionSystem.Quest.Testing
{
    public class TestRewardInfo : ICustomInfo
    {
        private readonly TestReward _reward;
        private readonly TestRewardDisplayerMB _displayerPrefab;

        public TestRewardInfo(TestReward reward, TestRewardDisplayerMB displayerPrefab)
        {
            _reward = reward ?? throw new ArgumentNullException(nameof(reward));
            _displayerPrefab = displayerPrefab != null ? displayerPrefab : throw new ArgumentNullException(nameof(displayerPrefab));
        }

        public GameObject CreateInfoObject()
        {
            TestRewardDisplayerMB displayer = UnityEngine.Object.Instantiate(_displayerPrefab);
            displayer.DisplayReward(_reward);
            return displayer.gameObject;
        }
    }
}