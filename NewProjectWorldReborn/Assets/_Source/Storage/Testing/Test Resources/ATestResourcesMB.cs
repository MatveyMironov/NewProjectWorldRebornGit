using ResourceSystem;
using UnityEngine;

namespace StorageSystem.Testing
{
    internal abstract class ATestResourcesMB : MonoBehaviour
    {
        [SerializeField] private SResourceCountsDictionary resourceCounts;

        protected abstract IStorage Storage { get; }

        protected virtual void Start()
        {
            foreach (var resourceCount in resourceCounts.GetResourceCountsDictionary())
            {
                Storage.AddResource(resourceCount.Key, resourceCount.Value);
            }
        }
    }
}