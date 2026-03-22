using CellIndicatorSystem;
using CellsVisualizationSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GridEditingSystem
{
    public class AddingCellsState : AEditingGridState
    {
        private readonly ICellsVisualization _addedCellsVisualization;

        public AddingCellsState(HashSet<Vector2Int> validCells,
                                ICellIndicator cellIndicator,
                                ICellsVisualization validCellsVisualization,
                                ICellsVisualization addedCellsVisualization) : base(validCells,
                                                                                   cellIndicator,
                                                                                   validCellsVisualization)
        {
            _addedCellsVisualization = addedCellsVisualization ?? throw new System.ArgumentNullException(nameof(addedCellsVisualization));
        }

        protected override void OnDeselectCells()
        {
            _addedCellsVisualization.DestroyVisualization();
        }

        protected override void ManageCellsToSelect(HashSet<Vector2Int> cellsToSelect)
        {
            foreach (var cell in cellsToSelect.ToArray())
            {
                if (ValidCells.Contains(cell))
                {
                    cellsToSelect.Remove(cell);
                }
            }

            SelectedCells.UnionWith(cellsToSelect);
            _addedCellsVisualization.CreateVisualization(SelectedCells.ToArray());
        }

        protected override void OnFinishAction()
        {
            ValidCells.UnionWith(SelectedCells);
        }
    }
}