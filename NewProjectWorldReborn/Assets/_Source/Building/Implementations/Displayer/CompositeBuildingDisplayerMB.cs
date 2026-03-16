using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class CompositeBuildingDisplayerMB : ABuildingDisplayerMB
    {
        [SerializeField] private ABuildingDisplayerMB[] displayers = new ABuildingDisplayerMB[0];

        public override void DisplayBuilding(Building building)
        {
            foreach (var displayer in displayers)
            {
                displayer.DisplayBuilding(building);
            }
        }

        public override void Clear()
        {
            foreach (var displayer in displayers)
            {
                displayer.Clear();
            }
        }
    }
}