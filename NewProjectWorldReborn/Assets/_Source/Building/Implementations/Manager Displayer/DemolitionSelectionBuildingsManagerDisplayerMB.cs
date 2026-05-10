using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class DemolitionSelectionBuildingsManagerDisplayerMB : ABuildingsManagerDisplayerMB
    {
        [SerializeField] private ABuildingDisplayerMB buildingDisplayer;

        protected virtual void OnDestroy()
        {
            Clear();
        }

        private IStructureBuildingsManager _displayedManager;

        private readonly Dictionary<Building, Action> _buildings_ShowDemolitionSelectionActions = new();

        public override void DisplayBuildingsManager(IStructureBuildingsManager manager)
        {
            Clear();
            _displayedManager = manager;

            manager.OnBuildingAdded += AddBuilding;
            manager.OnBuildingRemoved += RemoveBuilding;

            foreach (var building in manager.Buildings)
            {
                AddBuilding(building);
            }
        }

        public override void Clear()
        {
            if (_displayedManager == null) { return; }

            _displayedManager.OnBuildingAdded -= AddBuilding;
            _displayedManager.OnBuildingRemoved -= RemoveBuilding;

            foreach (var building in _buildings_ShowDemolitionSelectionActions.Keys.ToArray())
            {
                RemoveBuilding(building);
            }

            _displayedManager = null;
        }

        private void AddBuilding(Building building)
        {
            if (_buildings_ShowDemolitionSelectionActions.TryAdd(building, ShowBuildingDemolitionSelection))
            {
                building.OnSelectedForDemolition += _buildings_ShowDemolitionSelectionActions[building];
                //Debug.Log($"Building {building} added");
            }

            void ShowBuildingDemolitionSelection()
            {
                buildingDisplayer.DisplayBuilding(building);
            }
        }

        private void RemoveBuilding(Building building)
        {
            if (_buildings_ShowDemolitionSelectionActions.Remove(building, out Action action))
            {
                building.OnSelectedForDemolition += _buildings_ShowDemolitionSelectionActions[building];
                //Debug.Log($"Building {building} removed");
            }
        }
    }
}