using UnityEngine;
using UnityEngine.Events;

namespace ProgressionSystem.Implementations
{
    public class UnityEventQuestDisplayerMB : AQuestDisplayerMB
    {
        [SerializeField] private UnityEvent<Quest> displayQuest;
        [SerializeField] private UnityEvent clear;

        public override void DisplayQuest(Quest quest)
        {
            displayQuest.Invoke(quest);
        }

        public override void Clear()
        {
            clear.Invoke();
        }
    }
}