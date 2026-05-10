using System;
using UnityEngine;

namespace ConstructionControllerSystem
{
    public class ConstructionControllerMB : MonoBehaviour, IConstructionController
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask layers;
        [SerializeField] private Grid grid;

        private IConstructionController _controller;

        private void Awake()
        {
            _controller = new ConstructionController(mainCamera, layers, grid);
        }

        public bool HasEnteredState => _controller.HasEnteredState;

        public event Action OnStateEntered
        {
            add => _controller.OnStateEntered += value;
            remove => _controller.OnStateEntered -= value;
        }

        public event Action OnStateExited
        {
            add => _controller.OnStateExited += value;
            remove => _controller.OnStateExited -= value;
        }

        public void ExitState()
        {
            _controller.ExitState();
        }

        public void FinishAction()
        {
            _controller.FinishAction();
        }

        public void EnterState(IConstructionState state)
        {
            _controller.EnterState(state);
        }

        public void StartAction()
        {
            _controller.StartAction();
        }

        public void UpdateMousePosition(Vector2 mousePosition)
        {
            _controller.UpdateMousePosition(mousePosition);
        }
    }
}