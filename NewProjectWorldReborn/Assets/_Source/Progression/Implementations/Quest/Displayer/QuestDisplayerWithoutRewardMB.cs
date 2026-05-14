using UnityEngine;

namespace ProgressionSystem
{
    public class QuestDisplayerWithoutRewardMB : AQuestDisplayerMB
    {
        [SerializeField] private ATaskDisplayerMB taskDisplayer;

        public override void DisplayQuest(Quest quest)
        {
            taskDisplayer.DisplayTask(quest.Task);
        }

        public override void Clear()
        {
            taskDisplayer.Clear();
        }
    }
}