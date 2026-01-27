using UnityEngine;

namespace BuildingSystem
{
    public abstract class ABuildingConfigurationsManagerDisplayerMB : MonoBehaviour, IBuildingConfigurationsManagerDisplayer
    {
        public abstract void DisplayBuildingConfigurationsManager(IBuildingConfigurationsManager manager);
        public abstract void Clear();
    }
}