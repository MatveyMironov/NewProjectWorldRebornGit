using UnityEngine;

namespace ConstructionControllerSystem
{
    public interface IConstructionState
    {
        public void EnterState();
        public void UpdateState(Vector2Int cell);
        public void StartAction();
        public void FinishAction();
        public void ExitState();
    }
}
