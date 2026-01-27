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

        public ConstructedBuilding SelectedBuilding { get; private set; }

        public event Action OnBuildingSelected;
        public event Action OnBuildingDeselected;
        public event Action<ConstructedBuilding> OnBuildingDemolished;

        public void EnterState(Vector2Int cell)
        {

        }

        public void UpdateState(Vector2Int cell)
        {

        }

        public void StartAction(Vector2Int cell)
        {
            TrySelectBuilding(cell);
        }

        public void FinishAction(Vector2Int cell)
        {
            
        }

        public void ExitState()
        {
            DeselectBuilding();
        }

        public bool TryDemolishSelectedBuilding()
        {
            if (SelectedBuilding == null) return false;

            UnityEngine.Object.Destroy(SelectedBuilding.View.gameObject);
            _constructionGridManager.RemoveBuilding(SelectedBuilding);
            OnBuildingDemolished?.Invoke(SelectedBuilding);

            DeselectBuilding();

            return true;
        }

        public void DeselectBuilding()
        {
            HideDemolitionCells();

            SelectedBuilding = null;

            OnBuildingDeselected?.Invoke();
        }

        private bool TrySelectBuilding(Vector2Int cell)
        {
            if (_constructionGridManager.TryGetBuilding(cell, out ConstructedBuilding building))
            {
                building.View.ShowDemolition();
                //ShowDemolitionCells(building.OccupiedCells);

                SelectedBuilding = building;

                OnBuildingSelected?.Invoke();

                return true;
            }

            return false;
        }

        private void ShowDemolitionCells(HashSet<Vector2Int> cells)
        {
            HideDemolitionCells();

            _demolitionCellsVisualization.CreateVisualization(cells.ToArray());
        }

        private void HideDemolitionCells()
        {
            _demolitionCellsVisualization.DestroyVisualization();
        }
    }
}
