using ResourceSystem;
using System;

namespace StorageSystem
{
    public class StorageDisplayer : IStorageDisplayer
    {
        private readonly IResourceCountDisplayersManager _resourceCountDisplayersManager;

        public StorageDisplayer(IResourceCountDisplayersManager resourceCountDisplayersManager)
        {
            _resourceCountDisplayersManager = resourceCountDisplayersManager ?? throw new ArgumentNullException(nameof(resourceCountDisplayersManager));
        }

        private IStorage _displayedStorage;

        public void DisplayStorage(IStorage storage)
        {
            Clear();

            DisplayStoredResources();

            _displayedStorage = storage;

            void DisplayStoredResources()
            {
                foreach (var resource in storage.StoredResources)
                {
                    _resourceCountDisplayersManager.DisplayResourceCount(resource.Key, resource.Value);
                }

                storage.OnResourceCountChanged += DisplayResourceCount;
            }
        }

        public void Clear()
        {
            if (_displayedStorage == null) return;

            ClearStoredResources();

            _displayedStorage = null;

            void ClearStoredResources()
            {
                if (_displayedStorage != null)
                {
                    _displayedStorage.OnResourceCountChanged -= DisplayResourceCount;
                }

                _resourceCountDisplayersManager.Clear();
            }
        }

        private void DisplayResourceCount(IResourceDefinition resource)
        {
            int count = _displayedStorage.GetResourceCount(resource);
            _resourceCountDisplayersManager.DisplayResourceCount(resource, count);
        }
    }
}