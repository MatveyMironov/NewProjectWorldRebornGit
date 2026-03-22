using System;
using UnityEngine;

namespace ConstructionControllerSystem
{
    public interface IConstructionController
    {
        bool HasEnteredState { get; }

        event Action OnStateEntered;
        event Action OnStateExited;

        public void UpdateMousePosition(Vector2 mousePosition);
        public void EnterState(IConstructionState state);
        public void StartAction();
        public void ExitState();
        public void FinishAction();
    }
}