using HidableSystem;
using UnityEngine;

namespace ProgressionSystem
{
    public class HidableQuestDisplayerMB : AQuestDisplayerMB
    {
        [SerializeField] private AHidableMB hidable;
        [SerializeField] private AQuestDisplayerMB questDisplayer;

        public override void DisplayQuest(Quest quest)
        {
            questDisplayer.DisplayQuest(quest);
            hidable.Show();
        }

        public override void Clear()
        {
            questDisplayer.Clear();
            hidable.Hide();
        }
    }
}