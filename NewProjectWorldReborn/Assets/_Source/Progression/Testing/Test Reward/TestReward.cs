using CustomInfoSystem;
using System;
using UnityEngine;

namespace ProgressionSystem.Quest.Testing
{
    public class TestReward : IReward
    {
        public string Name { get; }

        public TestReward(string name, TestRewardDisplayerMB displayerPrefab)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));

            Info = new TestRewardInfo(this, displayerPrefab);
        }

        public ICustomInfo Info { get; }

        public void Reward()
        {
            Debug.Log($"{Name} is recieved");
        }
    }
}