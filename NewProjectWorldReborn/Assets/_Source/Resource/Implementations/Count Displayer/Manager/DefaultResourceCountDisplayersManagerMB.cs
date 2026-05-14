using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem
{
    public class DefaultResourceCountDisplayersManagerMB : AResourceCountDisplayersManagerMB
    {
        [SerializeField] private AResourceCountDisplayerSpawnerMB spawner;

        private readonly Dictionary<IResourceDefinition, AResourceCountDisplayerMB> _displayers = new();

        public override void DisplayResourceCount(IResourceDefinition resource, int count)
        {
            if (_displayers.ContainsKey(resource))
            {
                if (count > 0)
                {
                    _displayers[resource].DisplayCount(count);
                }
                else
                {
                    Destroy(_displayers[resource].gameObject);
                    _displayers.Remove(resource);
                }
            }
            else
            {
                if (count > 0)
                {
                    var displayer = spawner.SpawnDisplayer();
                    displayer.DisplayResource(resource);
                    displayer.DisplayCount(count);
                    _displayers.Add(resource, displayer);
                }
            }
        }

        public override void Clear()
        {
            foreach (var displayer in _displayers)
            {
                Destroy(displayer.Value.gameObject);
            }

            _displayers.Clear();
        }
    }
}