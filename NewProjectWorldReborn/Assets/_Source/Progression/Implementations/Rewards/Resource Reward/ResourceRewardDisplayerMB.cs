using CustomUISystem;
using ResourceSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class ResourceRewardDisplayerMB : MonoBehaviour
    {
        [SerializeField] private AResourceDisplayerMB resourceDisplayer;
        [SerializeField] private ANumberDisplayerMB amountDisplayer;

        public void DisplayReward(ResourceReward reward)
        {
            resourceDisplayer.DisplayResource(reward.Resource);
            amountDisplayer.DisplayNumber(reward.Amount);
        }

        public void ClearDisplayer()
        {
            resourceDisplayer.Clear();
            amountDisplayer.DisplayNumber(0);
        }
    }
}