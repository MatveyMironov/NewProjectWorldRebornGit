using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class TaskDisplayerSpawnerMB : ATaskDisplayerSpawnerMB
    {
        [SerializeField] private ATaskDisplayerMB prefab;
        [SerializeField] private Transform parent;

        public override ATaskDisplayerMB SpawnTaskDisplayer()
        {
            return Instantiate(prefab, parent);
        }
    }
}