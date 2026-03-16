using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class CompositeBuildingConfigurationDisplayerMB : ABuildingConfigurationDisplayerMB
    {
        [SerializeField] private ABuildingConfigurationDisplayerMB[] displayers = new ABuildingConfigurationDisplayerMB[0];

        public override void DisplayBuildingConiguration(IBuildingConfiguration configuration)
        {
            foreach (var displayer in displayers)
            {
                displayer.DisplayBuildingConiguration(configuration);
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