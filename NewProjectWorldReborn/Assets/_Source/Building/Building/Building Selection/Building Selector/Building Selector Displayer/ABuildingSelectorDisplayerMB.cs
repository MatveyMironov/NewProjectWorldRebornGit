using UnityEngine;

namespace BuildingSystem
{
    public abstract class ABuildingSelectorDisplayerMB : MonoBehaviour, IBuildingSelectorDisplayer
    {
        public abstract void DisplayBuildingSelector(IBuildingSelector selector);
        public abstract void Clear();
    }
}