using System;
using UnityEngine;

namespace ConstructionControllerSystem
{
    public class ConstructionController : IConstructionController
    {
        private readonly Camera _mainCamera;
        private readonly LayerMask _layers;
        private readonly Grid _grid;

        public ConstructionController(Camera mainCamera, LayerMask layers, Grid grid)
        {
            _mainCamera = mainCamera != null ? mainCamera : throw new ArgumentNullException(nameof(mainCamera));
            _layers = layers;
            _grid = grid != null ? grid : throw new ArgumentNullException(nameof(grid));
        }

        private IConstructionState _currentState;
        private Vector2Int _lastCell;

        public bool HasEnteredState => _currentState != null;
        public event Action OnStateEntered;
        public event Action OnStateExited;

        private bool IsMouseOverUI => MouseOverUIChecker.CheckIfMouseIsOverUI();
        private bool IsCurrentStateNull => _currentState == null;

        public void UpdateMousePosition(Vector2 mousePosition)
        {
            if (IsCurrentStateNull) { return; }
            if (IsMouseOverUI) { return; }

            Ray ray = _mainCamera.ScreenPointToRay(mousePosition);

            if (!Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _layers)) { return; }

            Vector3 worldPosition = hit.point;
            Vector3Int gridPosition = _grid.WorldToCell(worldPosition);
            Vector2Int cell = new(gridPosition.x, gridPosition.z);

            if (_lastCell == cell) { return; }

            _lastCell = cell;
            _currentState.UpdateState(cell);
        }

        public void EnterState(IConstructionState state)
        {
            ExitState();
            _currentState = state;
            state.EnterState(_lastCell);
            state.UpdateState(_lastCell);
            OnStateEntered?.Invoke();
        }

        public void ExitState()
        {
            if (IsCurrentStateNull) { return; }

            _currentState.ExitState();
            _currentState = null;
            OnStateExited?.Invoke();
        }

        public void StartAction()
        {
            if (IsCurrentStateNull) { return; }
            if (IsMouseOverUI) { return; }

            _currentState.StartAction(_lastCell);
        }

        public void FinishAction()
        {
            if (IsCurrentStateNull) { return; }
            if (IsMouseOverUI) { return; }

            _currentState.FinishAction(_lastCell);
        }
    }
}