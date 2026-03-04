using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class SingletonBuildingDisplayerSetuper : MonoBehaviour
    {
        [SerializeField] private ABuildingDisplayerMB buildingDisplayer;

        private void Start()
        {
            BuildingSelectorSingleton.Instance.OnBuildingSelected += DisplayBuilding;
        }

        private void OnDestroy()
        {
            BuildingSelectorSingleton.Instance.OnBuildingSelected -= DisplayBuilding;
        }

        private void DisplayBuilding(Building building)
        {
            buildingDisplayer.DisplayBuilding(building);
        }
    }
}