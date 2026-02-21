using ResourceSystem;
using StorageSystem;
using UnityEngine;

namespace ProgressionSystem.Quest.Implementations
{
    [CreateAssetMenu(fileName = "New Resource Reward", menuName = "Progression/Reward Configuration/Resource Reward")]
    public class ResourceRewardConfigurationSO : ARewardConfigurationSO
    {
        [SerializeField] private ResourceDefinitionSO resource;
        [SerializeField] private int amount;
        [SerializeField] private ResourceRewardDisplayerMB displayerPrefab;

        public override IReward CreateReward()
        {
            return new ResourceReward(StorageSingleton.Instance, resource, amount, displayerPrefab);
        }
    }
}