using ResourceSystem;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class ResourceRewardDisplayerMB : MonoBehaviour
    {
        [SerializeField] private AResourceCountDisplayerMB resourceCountDisplayer;

        public void DisplayReward(ResourceReward reward)
        {
            resourceCountDisplayer.DisplayResource(reward.Resource);
            resourceCountDisplayer.DisplayCount(reward.Amount);
        }

        public void ClearDisplayer()
        {
            resourceCountDisplayer.DisplayCount(0);
        }
    }
}