using UnityEngine;

namespace ProgressionSystem.Quest.Testing
{
    [CreateAssetMenu(fileName = "New Test Reward", menuName = "Progression/Reward Configuration/Test Reward")]
    public class TestRewardConfiguration : ARewardConfigurationSO
    {
        [SerializeField] private TestRewardDisplayerMB displayerPrefab;

        public override IReward CreateReward()
        {
            return new TestReward(name, displayerPrefab);
        }
    }
}