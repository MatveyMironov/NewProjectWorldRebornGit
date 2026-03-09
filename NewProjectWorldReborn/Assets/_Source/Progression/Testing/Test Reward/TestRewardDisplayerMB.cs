using TMPro;
using UnityEngine;

namespace ProgressionSystem.Testing
{
    public class TestRewardDisplayerMB : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI descriptionText;

        public void DisplayReward(TestReward reward)
        {
            descriptionText.text = $"Reward is a debug message: {reward.Name}";
        }

        public void Clear()
        {
            descriptionText.text = "";
        }
    }
}