namespace PlacingSystem
{
    public class BuildingRotationController : IBuildingRotationController
    {
        private PlacingState _placingState;

        public void ProvidePlacingState(PlacingState state)
        {
            _placingState = state;
        }

        public void RotateBuilding()
        {
            _placingState?.RotateBuilding();
        }
    }
}