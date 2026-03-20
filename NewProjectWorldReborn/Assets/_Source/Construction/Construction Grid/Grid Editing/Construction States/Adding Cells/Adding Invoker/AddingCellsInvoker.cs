using CellIndicatorSystem;
using ConstructionControllerSystem;
using CellsVisualizationSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace GridEditingSystem
{
    public class AddingCellsInvoker : IAddingCellsInvoker
    {
        private readonly IConstructionController _constructionController;
        private readonly AddingCellsState _addingCellsState;

        public AddingCellsInvoker(IConstructionController constructionController,
                                              HashSet<Vector2Int> validCells,
                                              ICellIndicator cellIndicator,
                                              ICellsVisualization validCellsVisualization,
                                              ICellsVisualization addedCellsVisualization)
        {
            _constructionController = constructionController ?? throw new ArgumentNullException(nameof(constructionController));

            _addingCellsState = new(validCells, cellIndicator, validCellsVisualization, addedCellsVisualization);
        }

        public void InvokeAddingCells()
        {
            _constructionController.EnterState(_addingCellsState);
        }
    }
}