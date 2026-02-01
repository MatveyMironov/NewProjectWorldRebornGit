using UnityEngine;

namespace BuildingConstructionUISystem
{
    public class BuildingConstructionButtonSpawnerMB : MonoBehaviour, IBuildingConstructionButtonSpawner
    {
        [SerializeField] private BuildingConstructionButtonMB prefab;
        [SerializeField] private Transform parent;

        public BuildingConstructionButtonMB SpawnButton()
        {
            return Instantiate(prefab, parent);
        }
    }
}