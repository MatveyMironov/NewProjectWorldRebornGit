using ConstructionGridSystem;
using DemolishingSystem;
using UnityEngine;

namespace BuildingSystem.Implementations
{
    public class BuildingDemolishingRegisterMB : MonoBehaviour
    {
        [SerializeField] private DemolitionControllerMB demolitionController;

        private IStructureBuildingsManager _buildingsManager;

        private void Awake()
        {
            _buildingsManager = StructureBuildingsManagerSingleton.Instance;
        }

        private void Start()
        {
            demolitionController.OnBuildingDemolished += RemoveBuilding;
        }

        private void OnDestroy()
        {
            demolitionController.OnBuildingDemolished -= RemoveBuilding;
        }

        private void RemoveBuilding(BuildingStructure structure)
        {
            _buildingsManager.TryRemoveBuildingInterior(structure);
        }
    }
}