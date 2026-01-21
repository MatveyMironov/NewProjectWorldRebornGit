using CustomUISystem;
using TMPro;
using UnityEngine;

namespace NeedSystem.Implementations
{
    public class NeedDisplayerMB : ANeedDisplayerMB
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private ANumberDisplayerMB satisfactionDisplayer;

        private INeed _displayedNeed;

        private void OnDestroy()
        {
            Clear();
        }

        public override void DisplayNeed(INeed need)
        {
            Clear();

            DisplayName();
            DisplaySatisfaction();

            _displayedNeed = need;

            void DisplayName()
            {
                nameText.text = need.Name;
            }

            void DisplaySatisfaction()
            {
                this.DisplaySatisfaction(need.Satisfaction);
                need.OnSatisfactionChanged += DisplayNeedSatisfaction;
            }
        }

        public override void Clear()
        {
            if (_displayedNeed == null) return;

            ClearName();
            ClearSatisfaction();

            void ClearName()
            {
                nameText.text = "";
            }

            void ClearSatisfaction()
            {
                _displayedNeed.OnSatisfactionChanged -= DisplayNeedSatisfaction;
                DisplaySatisfaction(0.0f);
            }

            _displayedNeed = null;
        }

        private void DisplayNeedSatisfaction()
        {
            DisplaySatisfaction(_displayedNeed.Satisfaction);
        }

        private void DisplaySatisfaction(float number)
        {
            satisfactionDisplayer.DisplayNumber(number);
        }
    }
}