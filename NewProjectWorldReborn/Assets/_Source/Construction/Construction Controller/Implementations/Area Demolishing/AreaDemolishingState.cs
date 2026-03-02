using CellIndicatorSystem;
using ConstructionControllerSystem;
using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace AreaDemolishingSystem
{
    internal class AreaDemolishingState : IConstructionState
    {
        private readonly IConstructionGridManager _constructionGridManager;
        private readonly ICellIndicator _cellIndicator;
        private readonly ICellsVisualization _demolishingCellsVisualization;

        public AreaDemolishingState(IConstructionGridManager constructionGridManager,
                                    ICellIndicator cellIndicator,
                                    ICellsVisualization demolishingCellsVisualization)
        {
            _constructionGridManager = constructionGridManager ?? throw new ArgumentNullException(nameof(constructionGridManager));
            _cellIndicator = cellIndicator ?? throw new ArgumentNullException(nameof(cellIndicator));
            _demolishingCellsVisualization = demolishingCellsVisualization ?? throw new ArgumentNullException(nameof(demolishingCellsVisualization));
        }

        private bool _isSelecting;
        private Vector2Int _startCell;

        private readonly HashSet<ConstructionGrid.PlacementData> _selectedPlacements = new();

        public event Action<BuildingStructure> OnBuildingDemolished;

        public void EnterState(Vector2Int cell)
        {
            _cellIndicator.Show();
            _cellIndicator.MoveToCell(cell);
        }

        public void UpdateState(Vector2Int cell)
        {
            _cellIndicator.MoveToCell(cell);

            if (_isSelecting) Select(cell);
        }

        public void StartAction(Vector2Int cell)
        {
            _cellIndicator.Hide();

            _startCell = cell;
            Select(_startCell);

            _isSelecting = true;
        }

        public void FinishAction(Vector2Int cell)
        {
            _cellIndicator.Show();

            DemolishSelectedBuildings();
            Deselect();

            _isSelecting = false;
        }

        public void ExitState()
        {
            _cellIndicator.Hide();

            Deselect();

            _isSelecting = false;
        }

        private void Select(Vector2Int finishCell)
        {
            HashSet<Vector2Int> cellsToSelect = _constructionGridManager.GetAllCellsFromTo(_startCell, finishCell);
            HashSet<ConstructionGrid.PlacementData> placementsToSelect = _constructionGridManager.GetAllPlacementsIn(cellsToSelect);

            SelectCells(cellsToSelect);
            SelectPlacements(placementsToSelect);
        }

        private void Deselect()
        {
            DeselectCells();
            DeselectBuildings();
        }

        private void SelectCells(HashSet<Vector2Int> cellsToSelect)
        {
            DeselectCells();

            _demolishingCellsVisualization.CreateVisualization(cellsToSelect.ToArray());
        }

        private void DeselectCells()
        {
            _demolishingCellsVisualization.DestroyVisualization();
        }

        private void SelectPlacements(HashSet<ConstructionGrid.PlacementData> placementsToSelect)
        {
            DeselectBuildings();

            foreach (var placement in placementsToSelect)
            {
                placement.Structure.View.ShowDemolition();
            }

            _selectedPlacements.UnionWith(placementsToSelect);
        }

        private void DeselectBuildings()
        {
            foreach (var placement in _selectedPlacements)
            {
                placement.Structure.View.HideDemolition();

                _selectedPlacements.Remove(placement);
            }
        }

        private void DemolishSelectedBuildings()
        {
            foreach (var placement in _selectedPlacements)
            {
                UnityEngine.Object.Destroy(placement.Structure.View.gameObject);
                _constructionGridManager.TryRemoveStructure(placement.Structure);

                _selectedPlacements.Remove(placement);

                OnBuildingDemolished?.Invoke(placement.Structure);
            }
        }
    }
}