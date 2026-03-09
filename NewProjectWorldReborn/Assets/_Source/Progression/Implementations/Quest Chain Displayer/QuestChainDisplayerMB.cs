using UnityEngine;

namespace ProgressionSystem
{
    public class QuestChainDisplayerMB : AQuestChainDisplayerMB
    {
        [SerializeField] private AQuestDisplayerMB activeQuestDisplayer;

        private QuestChain _displayedChain;

        private void OnDestroy()
        {
            Clear();
        }

        public override void DisplayQuestChain(QuestChain chain)
        {
            Clear();

            DisplayActiveLink();

            _displayedChain = chain;

            void DisplayActiveLink()
            {
                if (chain.ActiveQuest != null) DisplayActiveQuest(chain.ActiveQuest);
                chain.OnActiveQuestChanged += DisplayChainActiveQuest;
            }
        }

        public override void Clear()
        {
            if (_displayedChain == null) return;

            _displayedChain.OnActiveQuestChanged -= DisplayChainActiveQuest;
            HideActiveQuest();
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
    }
}