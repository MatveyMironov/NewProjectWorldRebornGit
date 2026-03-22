using UnityEngine;

namespace ResourceSystem
{
    public class ResourceCountDisplayersManagerMB : AResourceCountDisplayersManagerMB
    {
        [SerializeField] private AResourceCountDisplayerSpawnerMB spawner;

        private IResourceCountDisplayersManager _manager;

        private void Awake()
        {
            _manager = new ResourceCountDisplayersManager(spawner);
        }

        public override void DisplayResourceCount(IResourceDefinition resource, int count)
        {
            _manager.DisplayResourceCount(resource, count);
        }

        public override void Clear()
        {
            _manager.Clear();
        }
    }
}