using UnityEngine;

namespace ResourceSystem
{
    public abstract class AResourceCountDisplayerSpawnerMB : MonoBehaviour, IResourceCountDisplayerSpawner
    {
        public abstract AResourceCountDisplayerMB SpawnDisplayer();
    }
}