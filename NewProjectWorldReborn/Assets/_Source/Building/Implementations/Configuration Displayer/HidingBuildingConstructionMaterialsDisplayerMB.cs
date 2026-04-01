using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class HidingBuildingConstructionMaterialsDisplayerMB : ABuildingConfigurationDisplayerMB
    {
        [SerializeField] private BuildingConstructionMaterialsDisplayerMB actualDisplayer;

        public override void DisplayBuildingConiguration(IBuildingConfiguration configuration)
        {
            if (configuration.ConstructionResources.Count == 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }

            actualDisplayer.DisplayBuildingConiguration(configuration);
        }

        public override void Clear()
        {
            gameObject.SetActive(false);

            actualDisplayer.Clear();
        }
    }
}