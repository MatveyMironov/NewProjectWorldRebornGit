using UnityEngine;

namespace ResourceSystem
{
    public class ResourceCountDisplayerSpawnerMB : AResourceCountDisplayerSpawnerMB
    {
        [SerializeField] private AResourceCountDisplayerMB prefab;
        [SerializeField] private Transform parent;

        public override AResourceCountDisplayerMB SpawnDisplayer()
        {
            return Instantiate(prefab, parent);
        }
    }
}