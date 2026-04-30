using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem
{
    public class PersistantResourceCountDisplayersManagerMB : AResourceCountDisplayersManagerMB
    {
        [SerializeField] private AResourceCountDisplayerSpawnerMB spawner;

        [Space]
        [SerializeField] private ResourceDefinitionSO[] displayedResources = new ResourceDefinitionSO[0];

        private readonly Dictionary<IResourceDefinition, AResourceCountDisplayerMB> _resources_countDisplayers = new();

        private void Awake()
        {
            foreach (var resource in displayedResources)
            {
                if (_resources_countDisplayers.TryAdd(resource, null))
                {
                    _resources_countDisplayers[resource] = spawner.SpawnDisplayer();
                    _resources_countDisplayers[resource].DisplayResource(resource);
                    _resources_countDisplayers[resource].gameObject.SetActive(false);
                }
            }
        }

        public override void DisplayResourceCount(IResourceDefinition resource, int count)
        {
            if (_resources_countDisplayers.TryGetValue(resource, out var displayer))
            {
                if (count <= 0)
                {
                    displayer.gameObject.SetActive(false);
                    return;
                }

                displayer.DisplayCount(count);
                displayer.gameObject.SetActive(true);
            }
        }

        public override void Clear()
        {
            foreach (var displayer in _resources_countDisplayers.Values)
            {
                displayer.gameObject.SetActive(false);
            }
        }
    }
}