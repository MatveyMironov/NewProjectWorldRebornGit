using UnityEngine;

namespace ProgressionSystem.Testing
{
    public class TestQuestChainMB : MonoBehaviour
    {
        [SerializeField] private QuestChainConfigurationSO configuration;
        [SerializeField] private AQuestChainDisplayerMB displayer;

        private void Start()
        {
            QuestChain questChain = configuration.CreateQuestChain();
            displayer.DisplayQuestChain(questChain);
            questChain.Start();
        }
    }
}