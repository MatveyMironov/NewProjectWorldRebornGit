using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class SingletonBuildingSelectorDeselectorMB : MonoBehaviour
    {
        private IBuildingSelector Selector => BuildingSelectorSingleton.Instance;

        public void DeselectBuilding()
        {
            //Debug.Log("Building deselected");
            Selector.DeselectBuilding();
        }
    }
}