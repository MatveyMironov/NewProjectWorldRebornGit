using UnityEngine;

namespace ConstructionControllerSystem
{
    public interface IConstructionController
    {
        public void UpdateMousePosition(Vector2 mousePosition);
        public void SetState(IConstructionState state);
        public void StartAction();
        public void AbortAction();
        public void FinishAction();
    }
}