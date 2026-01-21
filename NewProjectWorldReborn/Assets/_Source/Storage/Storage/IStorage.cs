using ResourceSystem;
using System;
using System.Collections.Generic;

namespace StorageSystem
{
    public interface IStorage
    {
        event Action<IResourceDefinition, int> OnResourceAdded;
        event Action<IResourceDefinition, int> OnResourceRemoved;
        event Action<IResourceDefinition> OnResourceCountChanged;

        Dictionary<IResourceDefinition, int> StoredResources { get; }

        int GetResourceCount(IResourceDefinition resource);
        void AddResource(IResourceDefinition resource, int amount);
        bool TryRemoveResource(IResourceDefinition resource, int amount);
    }
}