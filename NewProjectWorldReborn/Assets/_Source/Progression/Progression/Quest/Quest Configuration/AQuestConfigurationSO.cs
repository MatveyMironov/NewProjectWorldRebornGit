using UnityEngine;

namespace ProgressionSystem.Quest
{
    public abstract class AQuestConfigurationSO : ScriptableObject, IQuestConfiguration
    {
        public abstract Quest CreateQuest();
    }
}