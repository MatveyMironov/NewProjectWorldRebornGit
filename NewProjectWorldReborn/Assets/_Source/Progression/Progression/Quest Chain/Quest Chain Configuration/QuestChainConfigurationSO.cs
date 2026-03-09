using UnityEngine;

namespace ProgressionSystem
{
    [CreateAssetMenu(fileName = "New Quest Chain", menuName = "Progression/Quest Chain Configuration")]
    public class QuestChainConfigurationSO : ScriptableObject, IQuestChainConfiguration
    {
        [SerializeField] private AQuestConfigurationSO[] quests = new AQuestConfigurationSO[0];

        public QuestChain CreateQuestChain()
        {
            return new(quests);
        }
    }
}