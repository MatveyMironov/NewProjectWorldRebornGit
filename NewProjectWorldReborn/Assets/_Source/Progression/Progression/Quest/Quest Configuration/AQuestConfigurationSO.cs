using UnityEngine;

namespace ProgressionSystem
{
    public abstract class AQuestConfigurationSO : ScriptableObject, IQuestConfiguration
    {
        public abstract Quest CreateQuest();
    }
}