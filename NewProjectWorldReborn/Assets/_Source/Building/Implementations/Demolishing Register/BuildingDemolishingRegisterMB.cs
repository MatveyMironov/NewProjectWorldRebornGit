using ConstructionGridSystem;
using DemolishingSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class BuildingDemolishingRegisterMB : MonoBehaviour
    {
        [SerializeField] private DemolishingInvokerMB demolishingInvoker;

        private IStructureBuildingsManager _buildingsManager;

        private void Awake()
        {
            _buildingsManager = StructureBuildingsManagerSingleton.Instance;
        }

        private void Start()
        {
            demolishingInvoker.OnBuildingDemolished += RemoveBuilding;
        }

        private void OnDestroy()
        {
            demolishingInvoker.OnBuildingDemolished -= RemoveBuilding;
        }

        private void RemoveBuilding(BuildingStructure structure)
        {
            _buildingsManager.TryRemoveBuildingInterior(structure);
        }
    }
}