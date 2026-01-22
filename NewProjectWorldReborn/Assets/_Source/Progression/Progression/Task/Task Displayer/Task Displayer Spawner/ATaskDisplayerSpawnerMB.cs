using UnityEngine;

namespace ProgressionSystem
{
    public abstract class ATaskDisplayerSpawnerMB : MonoBehaviour, ITaskDisplayerSpawner
    {
        public abstract ATaskDisplayerMB SpawnTaskDisplayer();
    }
}