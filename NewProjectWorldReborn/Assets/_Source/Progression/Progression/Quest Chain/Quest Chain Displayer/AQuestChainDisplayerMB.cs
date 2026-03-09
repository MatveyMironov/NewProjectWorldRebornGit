using UnityEngine;

namespace ProgressionSystem
{
    public abstract class AQuestChainDisplayerMB : MonoBehaviour, IQuestChainDisplayer
    {
        public abstract void DisplayQuestChain(QuestChain chain);
        public abstract void Clear();
    }
}