using UnityEngine;

namespace StorageSystem.Testing
{
    internal class TestResourcesMB : ATestResourcesMB
    {
        [SerializeField] private StorageMB storage;

        protected override IStorage Storage => storage;
    }
}