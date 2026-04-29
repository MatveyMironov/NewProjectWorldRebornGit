using UnityEngine;

namespace ProgressionSystem
{
    public class QuestChainDisplayerMB : AQuestChainDisplayerMB
    {
        [SerializeField] private AQuestDisplayerMB activeQuestDisplayer;

        [Space]
        [SerializeField] private AQuestChainDisplayerMB finishedQuestChainDisplayer;

        private QuestChain _displayedChain;

        private void OnDestroy()
        {
            Clear();
        }

        public override void DisplayQuestChain(QuestChain chain)
        {
            Clear();
            _displayedChain = chain;

            if (chain.ActiveQuest != null) { DisplayActiveQuest(chain.ActiveQuest); }
            chain.OnActiveQuestChanged += DisplayChainActiveQuest;

            chain.OnQuestChainFinished += DisplayQuestChainFinished;
        }

        public override void Clear()
        {
            if (_displayedChain == null) return;

            _displayedChain.OnActiveQuestChanged -= DisplayChainActiveQuest;
            HideActiveQuest();

            _displayedChain.OnQuestChainFinished -= DisplayQuestChainFinished;
        }

        private void DisplayChainActiveQuest()
        {
            DisplayActiveQuest(_displayedChain.ActiveQuest);
        }

        private void DisplayActiveQuest(Quest quest)
        {
            activeQuestDisplayer.DisplayQuest(quest);
        }

        private void HideActiveQuest()
        {
            activeQuestDisplayer.Clear();
        }

        private void DisplayQuestChainFinished()
        {
            finishedQuestChainDisplayer.DisplayQuestChain(_displayedChain);
        }
    }
}