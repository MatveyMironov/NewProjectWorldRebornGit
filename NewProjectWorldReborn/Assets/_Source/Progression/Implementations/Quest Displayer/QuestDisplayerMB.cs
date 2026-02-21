using UnityEngine;

namespace ProgressionSystem.Quest.Implementations
{
    public class QuestDisplayerMB : AQuestDisplayerMB
    {
        [SerializeField] private ATaskDisplayerMB taskDisplayer;
        [SerializeField] private ARewardDisplayerMB rewardDisplayer;

        public override void DisplayQuest(Quest quest)
        {
            taskDisplayer.DisplayTask(quest.Task);
            rewardDisplayer.DisplayReward(quest.Reward);
        }

        public override void Clear()
        {
            taskDisplayer.Clear();
            rewardDisplayer.Clear();
        }
    }
}