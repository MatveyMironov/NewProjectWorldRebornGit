using ResourceSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class ConstructionResourceBuildingConfigurationDisplayerMB : ABuildingConfigurationDisplayerMB
    {
        [SerializeField] private AResourceCountDisplayersManagerMB resourceCountDisplayersManager;

        private IBuildingConfiguration _displayedConfiguration;

        private void Start()
        {
            if (_displayedConfiguration == null) { return; }

            foreach (var resourceCount in _displayedConfiguration.ConstructionResources)
            {
                resourceCountDisplayersManager.DisplayResourceCount(resourceCount.Key, resourceCount.Value);
            }
        }

        public override void DisplayBuildingConiguration(IBuildingConfiguration configuration)
        {
            _displayedConfiguration = configuration;

            if (!gameObject.activeInHierarchy) { return; }

            foreach (var resourceCount in configuration.ConstructionResources)
            {
                resourceCountDisplayersManager.DisplayResourceCount(resourceCount.Key, resourceCount.Value);
            }
        }

        public override void Clear()
        {
            resourceCountDisplayersManager.Clear();
            _displayedConfiguration = null;
        }
    }
}