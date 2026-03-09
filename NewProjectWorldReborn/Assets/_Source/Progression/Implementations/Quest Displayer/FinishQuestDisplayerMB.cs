using UnityEngine;

namespace ProgressionSystem
{
    public class FinishQuestDisplayerMB : AQuestDisplayerMB
    {
        [SerializeField] private AQuestDisplayerMB activeQuestDisplayer;
        [SerializeField] private AQuestDisplayerMB finishedQuestDisplayer;

        private Quest _displayedQuest;

        public override void DisplayQuest(Quest quest)
        {
            Clear();
            _displayedQuest = quest;

            activeQuestDisplayer.DisplayQuest(quest);
            quest.OnFinished += DisplayFinishedQuest;
        }

        public override void Clear()
        {
            if (_displayedQuest == null) return;

            activeQuestDisplayer.Clear();
            _displayedQuest.OnFinished -= DisplayFinishedQuest;

            _displayedQuest = null;
        }

        private void DisplayFinishedQuest()
        {
            finishedQuestDisplayer.DisplayQuest(_displayedQuest);
        }
    }
}