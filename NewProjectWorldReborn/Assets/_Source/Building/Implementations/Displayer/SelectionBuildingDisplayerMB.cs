using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class SelectionBuildingDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private ABuildingDisplayerMB buildingDisplayer;

        public Building SelectedBuilding { get; private set; }

        public override void DisplayBuilding(Building building)
        {
            if (SelectedBuilding != null)
            {
                if (SelectedBuilding == building) { return; }

                SelectedBuilding.Deselect();
            }

            building.Select();
            //Debug.Log($"Building {building} selected by {gameObject.name}");
            SelectedBuilding = building;

            buildingDisplayer.DisplayBuilding(building);
        }

        public override void Clear()
        {
            if (SelectedBuilding == null) { return; }

            SelectedBuilding.Deselect();
            //Debug.Log($"Building {SelectedBuilding} deselected by {gameObject.name}");
            SelectedBuilding = null;

            buildingDisplayer.Clear();
        }
    }
}