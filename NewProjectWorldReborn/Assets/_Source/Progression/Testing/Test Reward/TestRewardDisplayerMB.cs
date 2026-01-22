using TMPro;
using UnityEngine;

namespace ProgressionSystem.Quest.Testing
{
    public class TestRewardDisplayerMB : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI descriptionText;

        public void DisplayReward(TestReward reward)
        {
            descriptionText.text = $"Reward is a debug message: {reward.FinishText}";
        }

        public void HideReward()
        {
            descriptionText.text = "";
        }
    }
}