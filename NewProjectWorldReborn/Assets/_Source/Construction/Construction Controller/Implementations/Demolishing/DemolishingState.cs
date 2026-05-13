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
        private readonly ICellsVisualization _demolitionAreaVisualization;

        public DemolishingState(IConstructionGridManager constructionGridManager,
                                ICellsVisualization demolitionAreaVisualization)
        {
            _constructionGridManager = constructionGridManager ?? throw new ArgumentNullException(nameof(constructionGridManager));
            _demolitionAreaVisualization = demolitionAreaVisualization ?? throw new ArgumentNullException(nameof(demolitionAreaVisualization));
        }

        private BuildingStructure _selectedStructure;
        public BuildingStructure SelectedStructure { get => _selectedStructure; }
        public event Action OnStructureSelected;
        public event Action OnStructureDeselected;

        public event Action<BuildingStructure> OnStructureDemolished;

        public event Action OnStateEntered;
        public event Action OnStateExited;

        public void EnterState()
        {
            OnStateEntered?.Invoke();
        }

        public void UpdateState(Vector2Int cell)
        {
            TrySelectStructureAt(cell);
        }

        public void StartAction()
        {
            TryDemolishSelectedStructure();

            bool TryDemolishSelectedStructure()
            {
                if (_selectedStructure == null) return false;
                BuildingStructure structureToDemolish = _selectedStructure;
                DeselectStructure();
                return TryDemolishStructure(structureToDemolish);

                bool TryDemolishStructure(BuildingStructure structure)
                {
                    if (!_constructionGridManager.TryRemoveStructure(structure)) { return false; }

                    structure.View.Demolish();
                    OnStructureDemolished?.Invoke(structure);
                    return true;
                }
            }
        }

        public void FinishAction()
        {

        }

        public void ExitState()
        {
            DeselectStructure();
            OnStateExited?.Invoke();
        }

        private bool TrySelectStructureAt(Vector2Int cell)
        {
            DeselectStructure();

            if (!_constructionGridManager.TryGetPlacementAt(cell, out ConstructionGrid.PlacementData placement)) { return false; }

            ShowDemolitionArea(placement.OccupiedCells.ToArray());

            BuildingStructure structureToSelect = placement.Structure;
            structureToSelect.View.OnSelectForDemolition();
            _selectedStructure = structureToSelect;
            OnStructureSelected?.Invoke();

            return true;

            void ShowDemolitionArea(Vector2Int[] cells)
            {
                _demolitionAreaVisualization.CreateVisualization(cells);
            }
        }

        private void DeselectStructure()
        {
            if (_selectedStructure == null) return;

            _selectedStructure.View.OnDeselectForDemolition();
            _selectedStructure = null;

            HideDemolitionArea();

            OnStructureDeselected?.Invoke();

            void HideDemolitionArea()
            {
                _demolitionAreaVisualization.DestroyVisualization();
            }
        }
    }
}