using UnityEngine;

namespace BuildingInfoSystem
{
    public abstract class ABuildingInfoDisplayerMB : MonoBehaviour, IBuildingInfoDisplayer
    {
        public abstract void DisplayBuildingInfo(IBuildingInfo info);
        public abstract void Clear();
    }
}