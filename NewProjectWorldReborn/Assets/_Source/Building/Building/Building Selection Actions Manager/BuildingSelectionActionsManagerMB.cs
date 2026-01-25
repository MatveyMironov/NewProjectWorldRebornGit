using System;
using UnityEngine;

namespace BuildingSystem
{
    public class BuildingSelectionActionsManagerMB : MonoBehaviour, IBuildingSelectionActionsManager
    {
        [SerializeField] private BuildingSelectorMB selector;

        private IBuildingSelectionActionsManager _manager;

        private void Awake()
        {
            _manager = new BuildingSelectionActionsManager(selector);
        }

        public bool TryAddBuildingSelectionAction(Building building)
        {
            return _manager.TryAddBuildingSelectionAction(building);
        }

        public bool TryRemoveBuildingSelectionAction(Building building)
        {
            return _manager.TryRemoveBuildingSelectionAction(building);
        }

        public bool TryGetBuildingSelectionAction(Building building, out Action selectBuilding)
        {
            return _manager.TryGetBuildingSelectionAction(building, out selectBuilding);
        }
    }
}