using UnityEngine;

namespace ProgressionSystem.Quest.QuestChain
{
    public abstract class AQuestChainDisplayerMB : MonoBehaviour, IQuestChainDisplayer
    {
        public abstract void DisplayQuestChain(QuestChain chain);
        public abstract void Clear();
    }
}