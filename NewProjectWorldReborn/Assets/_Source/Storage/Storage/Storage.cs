using ResourceSystem;
using System;
using System.Collections.Generic;

namespace StorageSystem
{
    public class Storage : IStorage
    {
        private readonly Dictionary<IResourceDefinition, int> _storedResources = new();

        public event Action<IResourceDefinition, int> OnResourceAdded;
        public event Action<IResourceDefinition, int> OnResourceRemoved;
        public event Action<IResourceDefinition> OnResourceCountChanged;

        public Dictionary<IResourceDefinition, int> StoredResources { get { return new(_storedResources); } }

        public int GetResourceCount(IResourceDefinition resource)
        {
            if (_storedResources.TryGetValue(resource, out int count))
            {
                return count;
            }

            return 0;
        }

        public void AddResource(IResourceDefinition resource, int amount)
        {
            if (_storedResources.ContainsKey(resource))
            {
                _storedResources[resource] += amount;
            }
            else
            {
                _storedResources.Add(resource, amount);
            }

            OnResourceAdded?.Invoke(resource, amount);
            OnResourceCountChanged?.Invoke(resource);
        }

        public bool TryRemoveResource(IResourceDefinition resource, int amount)
        {
            if (_storedResources.ContainsKey(resource))
                if (_storedResources[resource] >= amount)
                {
                    _storedResources[resource] -= amount;
                    OnResourceRemoved?.Invoke(resource, amount);
                    OnResourceCountChanged?.Invoke(resource);
                    return true;
                }

            return false;
        }
    }
}