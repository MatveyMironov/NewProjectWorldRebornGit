using UnityEngine;

namespace ProgressionSystem.Quest.Implementations
{
    [CreateAssetMenu(fileName = "New Quest", menuName = "Progression/Quest Configuration")]
    public class QuestConfigurationSO : AQuestConfigurationSO
    {
        [SerializeField] private ATaskConfigurationSO task;
        [SerializeField] private ARewardConfigurationSO reward;

        public override Quest CreateQuest()
        {
            return new(task.CreateTask(), reward.CreateReward());
        }
    }
}