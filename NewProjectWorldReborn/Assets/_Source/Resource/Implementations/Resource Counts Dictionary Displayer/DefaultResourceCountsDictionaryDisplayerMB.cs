using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Implementations
{
    public class DefaultResourceCountsDictionaryDisplayerMB : AResourceCountsDictionaryDisplayerMB
    {
        [SerializeField] private AResourceCountDisplayersManagerMB resourceCountDisplayersManager;

        public override void DisplayResourceCountsDictionary(Dictionary<IResourceDefinition, int> dictionary)
        {
            foreach (var resourceCount in dictionary)
            {
                resourceCountDisplayersManager.DisplayResourceCount(resourceCount.Key, resourceCount.Value);
            }
        }

        public override void Clear()
        {
            resourceCountDisplayersManager.Clear();
        }
    }
}