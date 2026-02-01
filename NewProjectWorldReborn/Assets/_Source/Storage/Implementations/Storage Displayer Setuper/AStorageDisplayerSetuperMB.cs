using UnityEngine;

namespace StorageSystem.Implementations
{
    public abstract class AStorageDisplayerSetuperMB : MonoBehaviour
    {
        [SerializeField] private StorageDisplayerMB displayer;

        protected abstract IStorage Storage { get; }

        protected virtual void Start()
        {
            displayer.DisplayStorage(Storage);
        }
    }
}