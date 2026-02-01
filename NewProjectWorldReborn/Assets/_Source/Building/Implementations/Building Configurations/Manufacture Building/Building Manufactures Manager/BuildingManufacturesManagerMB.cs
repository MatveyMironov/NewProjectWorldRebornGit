using ManufactureSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class BuildingManufacturesManagerMB : MonoBehaviour, IBuildingManufacturesManager
    {
        [SerializeField] private ManufacturesManagerMB manufacturesManager;

        private IBuildingManufacturesManager _manager;

        private void Awake()
        {
            _manager = new BuildingManufacturesManager(manufacturesManager);
        }

        public bool TryAddBuildingManufacture(Building building, IManufacture manufacture)
        {
            return _manager.TryAddBuildingManufacture(building, manufacture);
        }

        public bool TryRemoveBuildingManufacture(Building building)
        {
            return _manager.TryRemoveBuildingManufacture(building);
        }
    }
}