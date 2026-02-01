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

        private IConstructionState _state;
        private Vector2Int _lastCell;

        public void UpdateMousePosition(Vector2 mousePosition)
        {
            if (_state == null) return;
            
            Ray ray = _mainCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, _layers))
            {
                Vector3 worldPosition = hit.point;
                Vector3Int gridPosition = _grid.WorldToCell(worldPosition);
                Vector2Int cell = new(gridPosition.x, gridPosition.z);

                if (_lastCell != cell)
                {
                    _lastCell = cell;
                    _state.UpdateState(cell);
                }
            }
        }

        public void SetState(IConstructionState state)
        {
            AbortAction();

            if (state == null) return;

            state.EnterState(_lastCell);
            state.UpdateState(_lastCell);

            _state = state;
        }

        public void StartAction()
        {
            if (_state == null) return;

            _state.StartAction(_lastCell);
        }

        public void AbortAction()
        {
            if (_state == null) return;

            _state.ExitState();
            _state = null;
        }

        public void FinishAction()
        {
            if (_state == null) return;
            
            _state.FinishAction(_lastCell);
        }
    }
}