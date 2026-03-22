using CustomInfoSystem;
using ResourceSystem;
using StorageSystem;
using System;

namespace ProgressionSystem.Implementations
{
    public class ResourceReward : IReward
    {
        private readonly IStorage _storage;

        public ResourceReward(IStorage storage, IResourceDefinition resource, int amount, ResourceRewardDisplayerMB displayerPrefab)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
            Resource = resource ?? throw new ArgumentNullException(nameof(resource));
            Amount = amount;

            Info = new ResourceRewardInfo(this, displayerPrefab);
        }

        public IResourceDefinition Resource { get; }
        public int Amount { get; }

        public ICustomInfo Info { get; }

        public void Reward()
        {
            _storage.AddResource(Resource, Amount);
        }
    }
}