using System;
using UnityEngine;

namespace ProgressionSystem
{
    public class QuestChain
    {
        private readonly IQuestConfiguration[] _quests;

        public QuestChain(IQuestConfiguration[] quests)
        {
            if (quests is null) throw new ArgumentNullException(nameof(quests));

            _quests = new IQuestConfiguration[quests.Length];

            for (int i = 0; i < quests.Length; i++)
            {
                _quests[i] = quests[i] ?? throw new ArgumentNullException("Quest chain contains empty links");
            }
        }

        private int _activeQuestIndex;
        public Quest ActiveQuest { get; private set; }
        public event Action OnActiveQuestChanged;

        public void Start()
        {
            StartActiveQuest();
        }

        private void ChangeActiveQuest()
        {
            CancelActiveQuest();
            _activeQuestIndex++;
            StartActiveQuest();
        }

        private void CancelActiveQuest()
        {
            if (ActiveQuest == null) return;

            ActiveQuest.OnFinished -= ChangeActiveQuest;
            ActiveQuest.Cancel();
        }

        private void StartActiveQuest()
        {
            if (_activeQuestIndex >= _quests.Length)
            {
                Finish();
                return;
            }

            ActiveQuest = _quests[_activeQuestIndex].CreateQuest();
            OnActiveQuestChanged?.Invoke();

            if (ActiveQuest.IsFinished)
            {
                _activeQuestIndex++;
                StartActiveQuest();
                return;
            }

            ActiveQuest.OnFinished += ChangeActiveQuest;
            ActiveQuest.Start();
        }

        private void Finish()
        {
            Debug.Log("Quest chain is finished");
        }
    }
}