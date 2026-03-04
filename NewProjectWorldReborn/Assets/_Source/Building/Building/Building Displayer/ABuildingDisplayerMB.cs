using UnityEngine;

namespace BuildingSystem
{
    public abstract class ABuildingDisplayerMB : MonoBehaviour, IBuildingDisplayer
    {
        public abstract void DisplayBuilding(Building building);
        public abstract void Clear();
    }
}