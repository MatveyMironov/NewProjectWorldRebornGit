using UnityEngine;

namespace PlacingSystem
{
    public class BuildingRotationControllerMB : MonoBehaviour, IBuildingRotationController
    {
        private IBuildingRotationController _buildingRotationController;

        private void Awake()
        {
            _buildingRotationController = new BuildingRotationController();
        }

        public void ProvidePlacingState(PlacingState state)
        {
            _buildingRotationController.ProvidePlacingState(state);
        }

        public void RotateBuilding()
        {
            _buildingRotationController.RotateBuilding();
        }
    }
}