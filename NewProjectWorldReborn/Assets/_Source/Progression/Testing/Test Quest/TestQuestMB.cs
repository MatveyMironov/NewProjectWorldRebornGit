using UnityEngine;

namespace ProgressionSystem.Testing
{
    public class TestQuestMB : MonoBehaviour
    {
        [SerializeField] private AQuestConfigurationSO configuration;
        [SerializeField] private AQuestDisplayerMB displayer;

        void Start()
        {
            Quest quest = configuration.CreateQuest();
            displayer.DisplayQuest(quest);
            quest.Start();
        }
    }
}