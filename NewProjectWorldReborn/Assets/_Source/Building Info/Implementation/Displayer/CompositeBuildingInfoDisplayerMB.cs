using UnityEngine;

namespace BuildingInfoSystem.Implementation
{
    public class CompositeBuildingInfoDisplayerMB : ABuildingInfoDisplayerMB
    {
        [SerializeField] private ABuildingInfoDisplayerMB[] displayers = new ABuildingInfoDisplayerMB[0];

        public override void DisplayBuildingInfo(IBuildingInfo info)
        {
            foreach (var displayer in displayers)
            {
                displayer.DisplayBuildingInfo(info);
            }
        }

        public override void Clear()
        {
            foreach(var displayer in displayers)
            {
                displayer.Clear();
            }
        }
    }
}