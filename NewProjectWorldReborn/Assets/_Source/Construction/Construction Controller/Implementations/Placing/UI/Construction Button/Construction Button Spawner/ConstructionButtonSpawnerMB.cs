using UnityEngine;

namespace ConstructionUISystem
{
    public class ConstructionButtonSpawnerMB : MonoBehaviour, IConstructionButtonSpawner
    {
        [SerializeField] private ConstructionButtonMB prefab;
        [SerializeField] private Transform root;

        public ConstructionButtonMB SpawnConstructionButton()
        {
            return Instantiate(prefab, root);
        }
    }
}