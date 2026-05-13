namespace PlacingSystem
{
    public interface IBuildingRotationController
    {
        public void ProvidePlacingState(IPlacingState state);

        public void RotateBuilding();
    }
}
