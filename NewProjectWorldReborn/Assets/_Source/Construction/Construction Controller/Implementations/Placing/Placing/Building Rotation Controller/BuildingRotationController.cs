namespace PlacingSystem
{
    public class BuildingRotationController : IBuildingRotationController
    {
        private IPlacingState _placingState;

        public void ProvidePlacingState(IPlacingState state)
        {
            _placingState = state;
        }

        public void RotateBuilding()
        {
            if (_placingState == null) { return; }

            _placingState.RotateBuilding();
        }
    }
}