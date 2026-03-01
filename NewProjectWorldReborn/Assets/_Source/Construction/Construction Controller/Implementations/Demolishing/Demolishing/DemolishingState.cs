using ConstructionControllerSystem;
using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DemolishingSystem
{
    public class DemolishingState : IConstructionState
    {
        private readonly IConstructionGridManager _constructionGridManager;
        private readonly ICellsVisualization _demolitionCellsVisualization;

        public DemolishingState(IConstructionGridManager constructionGridManager,
                                ICellsVisualization demolitionCellsVisualization)
        {
            _constructionGridManager = constructionGridManager ?? throw new ArgumentNullException(nameof(constructionGridManager));
            _demolitionCellsVisualization = demolitionCellsVisualization ?? throw new ArgumentNullException(nameof(demolitionCellsVisualization));
        }

        public Vector2Int CurrentCell { get; private set; }
        //public event Action OnCurrentCellChanged;

        private BuildingStructure _selectedBuilding;
        public BuildingStructure SelectedBuilding { get => _selectedBuilding; }
        public event Action OnBuildingSelected;
        public event Action OnBuildingDeselected;

        public event Action<BuildingStructure> OnBuildingDemolished;

        public event Action OnStateExited;

        public void EnterState(Vector2Int cell)
        {
            TrySelectBuilding(cell);
            CurrentCell = cell;
        }

        public void UpdateState(Vector2Int cell)
        {
            TrySelectBuilding(cell);
            CurrentCell = cell;
        }

        public void StartAction(Vector2Int cell)
        {
            TryDemolishSelectedBuilding();
            CurrentCell = cell;
        }

        public void FinishAction(Vector2Int cell)
        {
            CurrentCell = cell;
        }

        public void ExitState()
        {
            DeselectBuilding();
            OnStateExited?.Invoke();
        }

        private bool TrySelectBuilding(Vector2Int cell)
        {
            DeselectBuilding();

            if (_constructionGridManager.TryGetBuilding(cell, out _selectedBuilding, out HashSet<Vector2Int> occupiedCells))
            {
                _selectedBuilding.View.ShowDemolition();
                ShowDemolitionCells(occupiedCells);
                OnBuildingSelected?.Invoke();
                return true;
            }

            return false;
        }

        private void DeselectBuilding()
        {
            if (_selectedBuilding == null) return;

            _selectedBuilding.View.HideDemolition();
            HideDemolitionCells();
            _selectedBuilding = null;
            OnBuildingDeselected?.Invoke();
        }

        private void ShowDemolitionCells(HashSet<Vector2Int> cells)
        {
            //HideDemolitionCells();

            _demolitionCellsVisualization.CreateVisualization(cells.ToArray());
        }

        private void HideDemolitionCells()
        {
            _demolitionCellsVisualization.DestroyVisualization();
        }

        private bool TryDemolishSelectedBuilding()
        {
            if (_selectedBuilding == null) return false;

            UnityEngine.Object.Destroy(_selectedBuilding.View.gameObject);
            _constructionGridManager.RemoveBuilding(_selectedBuilding);
            OnBuildingDemolished?.Invoke(_selectedBuilding);

            DeselectBuilding();

            return true;
        }
    }
}