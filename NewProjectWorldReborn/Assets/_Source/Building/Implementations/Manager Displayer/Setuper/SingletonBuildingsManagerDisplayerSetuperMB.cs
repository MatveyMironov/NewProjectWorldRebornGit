using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class SingletonBuildingsManagerDisplayerSetuperMB : MonoBehaviour
    {
        [SerializeField] private ABuildingsManagerDisplayerMB buildingsManagerDisplayer;

        private readonly IStructureBuildingsManager _buildingsManager = StructureBuildingsManagerSingleton.Instance;

        private void Awake()
        {
            buildingsManagerDisplayer.DisplayBuildingsManager(_buildingsManager);
            //Debug.Log("Buildings manager displayer setup");
        }
    }
}