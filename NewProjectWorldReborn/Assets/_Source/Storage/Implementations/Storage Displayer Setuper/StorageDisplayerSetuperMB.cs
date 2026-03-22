using UnityEngine;

namespace StorageSystem.Implementations
{
    public class StorageDisplayerSetuperMB : AStorageDisplayerSetuperMB
    {
        [SerializeField] private StorageMB storage;

        protected override IStorage Storage => storage;
    }
}