using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class SingletonBuildingSelectorDisplayerSetuper : MonoBehaviour
    {
        [SerializeField] private ABuildingSelectorDisplayerMB buildingSelectorDisplayer;

        protected IBuildingSelector BuildingSelector => BuildingSelectorSingleton.Instance;

        private void Awake()
        {
            buildingSelectorDisplayer.DisplayBuildingSelector(BuildingSelector);
        }
    }
}