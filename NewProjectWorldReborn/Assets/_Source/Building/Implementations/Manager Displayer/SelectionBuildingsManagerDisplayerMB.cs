using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class SelectionBuildingsManagerDisplayerMB : ABuildingsManagerDisplayerMB
    {
        [SerializeField] private ABuildingDisplayerMB buildingDisplayer;

        protected virtual void OnDestroy()
        {
            Clear();
        }

        private IStructureBuildingsManager _displayedManager;

        private readonly Dictionary<Building, Action> _buildings_SelectionActions = new();

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

            //Debug.Log($"Manager {manager} displayed by {gameObject.name}");
        }

        public override void Clear()
        {
            if (_displayedManager == null) { return; }

            _displayedManager.OnBuildingAdded -= AddBuilding;
            _displayedManager.OnBuildingRemoved -= RemoveBuilding;

            foreach (var building in _buildings_SelectionActions.Keys.ToArray())
            {
                RemoveBuilding(building);
            }

            _displayedManager = null;

            //Debug.Log($"Displayer {gameObject.name} cleared");
        }

        private void AddBuilding(Building building)
        {
            if (_buildings_SelectionActions.TryAdd(building, Select))
            {
                building.OnInteracted += _buildings_SelectionActions[building];
                //Debug.Log($"Building {building} added");
            }

            void Select()
            {
                buildingDisplayer.DisplayBuilding(building);
            }
        }

        private void RemoveBuilding(Building building)
        {
            if (_buildings_SelectionActions.Remove(building, out Action action))
            {
                building.OnInteracted -= action;
                //Debug.Log($"Building {building} removed");
            }
        }
    }
}