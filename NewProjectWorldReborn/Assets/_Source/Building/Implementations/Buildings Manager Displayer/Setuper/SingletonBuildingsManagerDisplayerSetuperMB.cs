using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class SingletonBuildingsManagerDisplayerSetuperMB : MonoBehaviour
    {
        [SerializeField] private ABuildingsManagerDisplayerMB buildingsManagerDisplayer;

        private readonly IStructureBuildingsManager _buildingsManager = StructureBuildingsManagerSingleton.Instance;

        private void Start()
        {
            buildingsManagerDisplayer.DisplayBuildingsManager(_buildingsManager);
        }
    }
}