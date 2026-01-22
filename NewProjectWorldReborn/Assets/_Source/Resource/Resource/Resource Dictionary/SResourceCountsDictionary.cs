using System;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem
{
    [Serializable]
    public class SResourceCountsDictionary : IResourceCountsDictionary
    {
        [SerializeField] private List<ResourceContainer> resources = new();

        public Dictionary<IResourceDefinition, int> GetResourceCountsDictionary()
        {
            return ResourceContainersListToDictionary(resources);
        }

        private Dictionary<IResourceDefinition, int> ResourceContainersListToDictionary(List<ResourceContainer> list)
        {
            Dictionary<IResourceDefinition, int> dictionary = new();

            foreach (var resourceContainer in list)
            {
                if (resourceContainer.Resource == null) throw new ArgumentNullException(nameof(resourceContainer.Resource));

                if (resourceContainer.Count <= 0) throw new ArgumentOutOfRangeException("Resource count can not be negative!");

                if (dictionary.TryAdd(resourceContainer.Resource, resourceContainer.Count)) continue;

                dictionary[resourceContainer.Resource] += resourceContainer.Count;
            }

            return dictionary;
        }

        [Serializable]
        private struct ResourceContainer
        {
            [SerializeField] private ResourceDefinitionSO _resource;
            [SerializeField] private int _count;

            public readonly ResourceDefinitionSO Resource { get { return _resource; } }
            public readonly int Count { get { return _count; } }
        }
    }
}