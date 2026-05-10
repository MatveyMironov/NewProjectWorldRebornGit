using HidableSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class HidableBuildingDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private ABuildingDisplayerMB displayer;
        [SerializeField] private AHidableMB hidable;

        public override void DisplayBuilding(Building building)
        {
            hidable.Show();
            displayer.DisplayBuilding(building);
        }

        public override void Clear()
        {
            //Debug.Log("Cleared");
            hidable.Hide();
            displayer.Clear();
        }
    }
}