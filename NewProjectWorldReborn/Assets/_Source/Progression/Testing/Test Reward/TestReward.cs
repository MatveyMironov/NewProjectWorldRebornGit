using CustomInfoSystem;
using System;
using UnityEngine;

namespace ProgressionSystem.Quest.Testing
{
    public class TestReward : IReward
    {
        public string Name { get; }

        public TestReward(string finishText, TestRewardDisplayerMB displayerPrefab)
        {
            Name = finishText ?? throw new ArgumentNullException(nameof(finishText));

            Info = new TestRewardInfo(this, displayerPrefab);
        }

        public string FinishText => Name;

        public ICustomInfo Info { get; }

        public void Reward()
        {
            Debug.Log($"{Name} is recieved");
        }
    }
}