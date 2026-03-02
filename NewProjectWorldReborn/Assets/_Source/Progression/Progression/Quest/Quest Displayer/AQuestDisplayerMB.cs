using UnityEngine;

namespace ProgressionSystem.Quest
{
    public abstract class AQuestDisplayerMB : MonoBehaviour, IQuestDisplayer
    {
        public abstract void DisplayQuest(Quest quest);
        public abstract void Clear();
    }
}