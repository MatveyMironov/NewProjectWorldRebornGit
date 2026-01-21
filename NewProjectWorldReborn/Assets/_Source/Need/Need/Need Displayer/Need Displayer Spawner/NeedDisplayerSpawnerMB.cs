using UnityEngine;

namespace NeedSystem
{
    public class NeedDisplayerSpawnerMB : MonoBehaviour, INeedDisplayerSpawner
    {
        [SerializeField] private ANeedDisplayerMB prefab;
        [SerializeField] private Transform parent;

        public ANeedDisplayerMB SpawnNeedDisplayer()
        {
            return Instantiate(prefab, parent);
        }
    }
}