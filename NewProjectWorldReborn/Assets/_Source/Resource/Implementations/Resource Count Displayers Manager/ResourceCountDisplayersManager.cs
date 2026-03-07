using System;
using System.Collections.Generic;

namespace ResourceSystem
{
    public class ResourceCountDisplayersManager : IResourceCountDisplayersManager
    {
        private readonly IResourceCountDisplayerSpawner _displayerSpawner;

        public ResourceCountDisplayersManager(IResourceCountDisplayerSpawner displayerSpawner)
        {
            _displayerSpawner = displayerSpawner ?? throw new ArgumentNullException(nameof(displayerSpawner));
        }

        private readonly Dictionary<IResourceDefinition, AResourceCountDisplayerMB> _displayers = new();

        public void DisplayResourceCount(IResourceDefinition resource, int count)
        {
            if (_displayers.ContainsKey(resource))
            {
                if (count > 0)
                {
                    _displayers[resource].DisplayCount(count);
                }
                else
                {
                    UnityEngine.Object.Destroy(_displayers[resource].gameObject);
                    _displayers.Remove(resource);
                }
            }
            else
            {
                if (count > 0)
                {
                    var displayer = _displayerSpawner.SpawnDisplayer();
                    displayer.DisplayResource(resource);
                    displayer.DisplayCount(count);
                    _displayers.Add(resource, displayer);
                }
            }
        }

        public void Clear()
        {
            foreach (var displayer in _displayers)
            {
                UnityEngine.Object.Destroy(displayer.Value.gameObject);
            }

            _displayers.Clear();
        }
    }
}