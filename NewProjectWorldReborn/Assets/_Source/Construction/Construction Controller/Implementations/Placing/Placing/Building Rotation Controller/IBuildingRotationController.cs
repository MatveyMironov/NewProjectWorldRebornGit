namespace PlacingSystem
{
    public interface IBuildingRotationController
    {
        public void ProvidePlacingState(PlacingState state);

        public void RotateBuilding();
    }
}
