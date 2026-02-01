using UnityEngine;

namespace BuildingSystem
{
    public abstract class ABuildingConfigurationDisplayerMB : MonoBehaviour, IBuildingConfigurationDisplayer
    {
        public abstract void DisplayBuildingConiguration(IBuildingConfiguration configuration);
        public abstract void Clear();
    }
}