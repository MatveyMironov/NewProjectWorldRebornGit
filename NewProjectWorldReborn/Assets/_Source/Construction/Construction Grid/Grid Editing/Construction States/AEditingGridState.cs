using CellIndicatorSystem;
using ConstructionControllerSystem;
using CellsVisualizationSystem;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace GridEditingSystem
{
    public abstract class AEditingGridState : IConstructionState
    {
        private readonly ICellsVisualization _validCellsVisualization;
        private readonly ICellIndicator _cellIndicator;

        public AEditingGridState(HashSet<Vector2Int> validCells,
                                ICellIndicator cellIndicator,
                                ICellsVisualization gridCellVisualizationsMaterialSwitcher)
        {
            ValidCells = validCells ?? throw new System.ArgumentNullException(nameof(validCells));
            _validCellsVisualization = gridCellVisualizationsMaterialSwitcher ?? throw new System.ArgumentNullException(nameof(gridCellVisualizationsMaterialSwitcher));

            _cellIndicator = cellIndicator ?? throw new System.ArgumentNullException(nameof(cellIndicator));
        }

        private Vector2Int _currentCell;

        protected HashSet<Vector2Int> ValidCells { get; }
        protected HashSet<Vector2Int> SelectedCells { get; } = new();

        private Vector2Int _selectionStartCell;
        private bool _isSelecting;

        public void EnterState()
        {
            _cellIndicator.Show();
        }

        public void ExitState()
        {
            DeselectCells();

            _cellIndicator.Hide();

            _isSelecting = false;
        }

        public void UpdateState(Vector2Int cell)
        {
            _currentCell = cell;
            _cellIndicator.MoveToCell(cell);

            if (_isSelecting)
            {
                SelectCells(cell);
            }
        }

        public void StartAction()
        {
            _cellIndicator.Hide();

            _selectionStartCell = _currentCell;
            SelectCells(_selectionStartCell);

            _isSelecting = true;
        }

        public void FinishAction()
        {
            _cellIndicator.Show();

            OnFinishAction();
            DeselectCells();

            _validCellsVisualization.CreateVisualization(ValidCells.ToArray());

            _isSelecting = false;
        }

        protected abstract void OnDeselectCells();
        protected abstract void ManageCellsToSelect(HashSet<Vector2Int> cellsToSelect);
        protected abstract void OnFinishAction();

        private void SelectCells(Vector2Int selectionFinishCell)
        {
            DeselectCells();

            HashSet<Vector2Int> cellsToSelect = GetAllCellsFromTo(_selectionStartCell, selectionFinishCell);
            ManageCellsToSelect(cellsToSelect);
        }

        private void DeselectCells()
        {
            SelectedCells.Clear();
            OnDeselectCells();
        }

        private HashSet<Vector2Int> GetAllCellsFromTo(Vector2Int firstCell, Vector2Int secondCell)
        {
            HashSet<Vector2Int> cells = new();

            Vector2Int lowerLeftCorner = Vector2Int.zero;
            Vector2Int upperRightCorner = Vector2Int.zero;

            if (firstCell.x <= secondCell.x)
            {
                lowerLeftCorner.x = firstCell.x;
                upperRightCorner.x = secondCell.x;
            }
            else
            {
                lowerLeftCorner.x = secondCell.x;
                upperRightCorner.x = firstCell.x;
            }

            if (firstCell.y <= secondCell.y)
            {
                lowerLeftCorner.y = firstCell.y;
                upperRightCorner.y = secondCell.y;
            }
            else
            {
                lowerLeftCorner.y = secondCell.y;
                upperRightCorner.y = firstCell.y;
            }

            for (int x = lowerLeftCorner.x; x <= upperRightCorner.x; x++)
            {
                for (int y = lowerLeftCorner.y; y <= upperRightCorner.y; y++)
                {
                    Vector2Int cell = new(x, y);
                    cells.Add(cell);
                }
            }

            return cells;
        }
    }
}