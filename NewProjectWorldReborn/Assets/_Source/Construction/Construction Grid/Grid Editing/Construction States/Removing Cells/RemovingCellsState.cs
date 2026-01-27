using CellIndicatorSystem;
using CellsVisualizationSystem;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GridEditingSystem
{
    public class RemovingCellsState : AEditingGridState
    {
        private readonly ICellsVisualization _validCellsVisualization;
        private readonly ICellsVisualization _removedCellsVisualization;

        public RemovingCellsState(HashSet<Vector2Int> validCells,
                                  ICellIndicator cellIndicator,
                                  ICellsVisualization validCellsVisualization,
                                  ICellsVisualization removedCellsVisualization) : base(validCells,
                                                                                       cellIndicator,
                                                                                       validCellsVisualization)
        {
            _validCellsVisualization = validCellsVisualization ?? throw new System.ArgumentNullException(nameof(validCellsVisualization));
            _removedCellsVisualization = removedCellsVisualization ?? throw new System.ArgumentNullException(nameof(removedCellsVisualization));
        }

        protected override void OnDeselectCells()
        {
            _removedCellsVisualization.DestroyVisualization();
        }

        protected override void ManageCellsToSelect(HashSet<Vector2Int> cellsToSelect)
        {
            foreach (var cell in cellsToSelect.ToArray())
            {
                if (!ValidCells.Contains(cell))
                {
                    cellsToSelect.Remove(cell);
                }
            }

            SelectedCells.UnionWith(cellsToSelect);
            _removedCellsVisualization.CreateVisualization(SelectedCells.ToArray());

            HashSet<Vector2Int> validCellsAfterRemoving = new(ValidCells);
            validCellsAfterRemoving.ExceptWith(cellsToSelect);
            _validCellsVisualization.CreateVisualization(validCellsAfterRemoving.ToArray());
        }

        protected override void OnFinishAction()
        {
            ValidCells.ExceptWith(SelectedCells);
        }
    }
}