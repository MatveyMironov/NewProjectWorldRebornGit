using ConstructionGridSystem;
using UnityEngine;

namespace BuildingSystem
{
    public class StructureBuildingsManagerMB : MonoBehaviour, IStructureBuildingsManager
    {
        [Header("Selection")]
        [SerializeField] private BuildingSelectionActionsManagerMB buildingSelectionActionsManager;

        private IStructureBuildingsManager _manager;

        private void Awake()
        {
            _manager = new StructureBuildingsManager(buildingSelectionActionsManager);
        }

        public bool TryAddStructureBuilding(ConstructedBuilding structure, Building building)
        {
            return _manager.TryAddStructureBuilding(structure, building);
        }

        public bool TryRemoveBuildingInterior(ConstructedBuilding structure)
        {
            return _manager.TryRemoveBuildingInterior(structure);
        }

        public bool TryGetBuildingInterior(ConstructedBuilding structure, out Building building)
        {
            return _manager.TryGetBuildingInterior(structure, out building);
        }
    }
}