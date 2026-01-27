using UnityEngine;

namespace ConstructionControllerSystem
{
    public interface IConstructionState
    {
        public void EnterState(Vector2Int cell);
        public void UpdateState(Vector2Int cell);
        public void StartAction(Vector2Int cell);
        public void FinishAction(Vector2Int cell);
        public void ExitState();
    }
}
