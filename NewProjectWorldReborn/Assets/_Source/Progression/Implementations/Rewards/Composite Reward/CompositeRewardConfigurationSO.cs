using System.Collections.Generic;
using UnityEngine;

namespace ProgressionSystem
{
    [CreateAssetMenu(fileName = "New Composite Reward", menuName = "Progression/Reward Configuration/Composite Reward")]
    public class CompositeRewardConfigurationSO : ARewardConfigurationSO
    {
        [SerializeField] private ARewardConfigurationSO[] partConfigurations;
        [SerializeField] private CompositeRewardDisplayerMB displayerPrefab;

        public IRewardConfiguration[] SecuredParts => SecureParts(partConfigurations);

        public override IReward CreateReward()
        {
            List<IReward> parts = new();

            foreach (IRewardConfiguration part in SecuredParts)
            {
                AddReward(part);
            }

            return new CompositeReward(parts.ToArray(), displayerPrefab);

            void AddReward(IRewardConfiguration configuration)
            {
                if (configuration is CompositeRewardConfigurationSO composite)
                {
                    AddCompositeReward(composite);
                    return;
                }

                parts.Add(configuration.CreateReward());
            }

            void AddCompositeReward(CompositeRewardConfigurationSO composite)
            {
                foreach (IRewardConfiguration part in SecureParts(composite.SecuredParts))
                {
                    parts.Add(part.CreateReward());
                }
            }
        }

        private IRewardConfiguration[] SecureParts(IRewardConfiguration[] parts)
        {
            List<IRewardConfiguration> secureParts = new();

            foreach (IRewardConfiguration part in parts)
            {
                if ((object)part == this)
                {
                    Debug.Log($"ERROR! Composite reward [{name}] contains itself as a composite part. It will be removed.");
                    continue;
                }

                secureParts.Add(part);
            }

            return secureParts.ToArray();
        }
    }
}