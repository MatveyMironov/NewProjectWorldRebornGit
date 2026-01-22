using ResourceSystem;
using UnityEngine;

namespace StorageSystem
{
    public class StorageDisplayerMB : MonoBehaviour, IStorageDisplayer
    {
        [SerializeField] private AResourceCountDisplayersManager resourceCountDisplayersManager;

        private IStorageDisplayer _storageDisplayer;

        private void Awake()
        {
            _storageDisplayer = new StorageDisplayer(resourceCountDisplayersManager);
        }

        public void DisplayStorage(IStorage storage)
        {
            _storageDisplayer.DisplayStorage(storage);
        }

        public void Clear()
        {
            _storageDisplayer.Clear();
        }
    }
}