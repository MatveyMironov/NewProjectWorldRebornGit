using UnityEngine;
using UnityEngine.Events;

namespace ProgressionSystem.Implementations
{
    public class UnityEventQuestChainDisplayerMB : AQuestChainDisplayerMB
    {
        [SerializeField] private UnityEvent<QuestChain> displayQuestChain;
        [SerializeField] private UnityEvent clear;

        public override void DisplayQuestChain(QuestChain chain)
        {
            displayQuestChain.Invoke(chain);
        }

        public override void Clear()
        {
            clear.Invoke();
        }
    }
}