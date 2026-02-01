using ResourceSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace StorageSystem
{
    public class StorageMB : MonoBehaviour, IStorage
    {
        private IStorage _storage;

        private void Awake()
        {
            _storage = new Storage();
        }

        public Dictionary<IResourceDefinition, int> StoredResources => _storage.StoredResources;

        public event Action<IResourceDefinition, int> OnResourceAdded
        {
            add => _storage.OnResourceAdded += value;
            remove => _storage.OnResourceAdded -= value;
        }

        public event Action<IResourceDefinition, int> OnResourceRemoved
        {
            add => _storage.OnResourceRemoved += value;
            remove => _storage.OnResourceRemoved -= value;
        }

        public event Action<IResourceDefinition> OnResourceCountChanged
        {
            add => _storage.OnResourceCountChanged += value;
            remove => _storage.OnResourceCountChanged -= value;
        }

        public void AddResource(IResourceDefinition resource, int amount)
        {
            _storage.AddResource(resource, amount);
        }

        public int GetResourceCount(IResourceDefinition resource)
        {
            return _storage.GetResourceCount(resource);
        }

        public bool TryRemoveResource(IResourceDefinition resource, int amount)
        {
            return _storage.TryRemoveResource(resource, amount);
        }
    }
}