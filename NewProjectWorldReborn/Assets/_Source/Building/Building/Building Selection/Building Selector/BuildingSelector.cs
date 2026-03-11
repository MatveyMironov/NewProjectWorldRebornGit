using System;
using UnityEngine;

namespace BuildingSystem
{
    public class BuildingSelector : IBuildingSelector
    {
        public Building SelectedBuilding { get; private set; }
        public event Action<Building> OnBuildingSelected;
        public event Action OnBuildingDeselected;

        public void SelectBuilding(Building building)
        {
            if (SelectedBuilding != null)
            {
                if (SelectedBuilding == building) { return; }
                SelectedBuilding.Deselect();
            }

            SelectedBuilding = building;
            building.Select();
            OnBuildingSelected?.Invoke(building);
        }

        public void DeselectBuilding()
        {
            if (SelectedBuilding == null) { return; }

            SelectedBuilding.Deselect();
            //Debug.Log($"Building {SelectedBuilding} deselected");
            SelectedBuilding = null;
            OnBuildingDeselected?.Invoke();
        }
    }
}