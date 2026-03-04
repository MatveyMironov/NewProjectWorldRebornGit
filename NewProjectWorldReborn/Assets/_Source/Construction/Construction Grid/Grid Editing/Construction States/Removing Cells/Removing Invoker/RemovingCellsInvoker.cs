using CellIndicatorSystem;
using ConstructionControllerSystem;
using CellsVisualizationSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GridEditingSystem
{
    public class RemovingCellsInvoker : IRemovingCellsInvoker
    {
        private readonly IConstructionController _constructionController;
        private readonly RemovingCellsState _removingCellsState;

        public RemovingCellsInvoker(IConstructionController constructionController,
                                    HashSet<Vector2Int> validCells,
                                    ICellIndicator cellIndicator,
                                    ICellsVisualization validCellsVisualization,
                                    ICellsVisualization removedCellsVisualization)
        {
            _constructionController = constructionController ?? throw new ArgumentNullException(nameof(constructionController));

            _removingCellsState = new(validCells, cellIndicator, validCellsVisualization, removedCellsVisualization);
        }

        public void InvokeRemovingCellsState()
        {
            _constructionController.SetState(_removingCellsState);
        }
    }
}