using ConstructionControllerSystem;

namespace PlacingSystem
{

    public interface IPlacingState : IConstructionState
    {
        void RotateBuilding();
    }
}