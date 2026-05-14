using LayoutSystem;
using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace PlacingSystem
{
    public class PlacingState : IPlacingState
    {
        private readonly IConstructionConfiguration _constructionConfiguration;

        private readonly IConstructionGridManager _constructionGridManager;
        private readonly IConstructionPreviewFactory _previewFactory;
        private readonly ICellsVisualization _placementCellsVisualization;
        private readonly IBuildingStructureFactory _structureFactory;
        private readonly Action<BuildingStructure> _structurePlacedCallback;

        private readonly Layout _structureLayout;

        public PlacingState(IConstructionConfiguration constructionConfiguration,
                            IConstructionGridManager constructionGridManager,
                            IConstructionPreviewFactory previewFactory,
                            ICellsVisualization placementCellsVisualization,
                            IBuildingStructureFactory stractureFactory,
                            Action<BuildingStructure> structurePlacedCallback)
        {
            _constructionConfiguration = constructionConfiguration ?? throw new ArgumentNullException(nameof(constructionConfiguration));
            _constructionGridManager = constructionGridManager ?? throw new ArgumentNullException(nameof(constructionGridManager));
            _previewFactory = previewFactory ?? throw new ArgumentNullException(nameof(previewFactory));
            _placementCellsVisualization = placementCellsVisualization ?? throw new ArgumentNullException(nameof(placementCellsVisualization));
            _structureFactory = stractureFactory ?? throw new ArgumentNullException(nameof(stractureFactory));
            _structurePlacedCallback = structurePlacedCallback;

            _structureLayout = _constructionConfiguration.GetBuildingLayout();
        }

        private Vector2Int _currentCell;

        //Cashing hash set for perfomance
        private readonly HashSet<Vector2Int> _placementCells = new();

        private GameObject _previewObject;
        private ConstructionPreview _preview;

        public void EnterState()
        {
            CreatePlacementPreview();

            void CreatePlacementPreview()
            {
                _previewObject = _constructionConfiguration.CreateBuildingPreviewObject();
                _preview = _previewFactory.CreateConstructionPreview(_previewObject);
                _preview.SetOrientation(_structureLayout.Orientation);
            }
        }

        public void UpdateState(Vector2Int cell)
        {
            _currentCell = cell;
            ShowPlacementAt(cell);
        }

        public void StartAction()
        {
            TryPlaceStructureAt(_currentCell);

            bool TryPlaceStructureAt(Vector2Int cell)
            {
                if (!_constructionGridManager.CheckIfCanPlaceLayoutAt(cell, _structureLayout.OccupiedCells)) { return false; }

                BuildingStructure structure = _structureFactory.CreateBuildingStructure(cell, _structureLayout, _constructionConfiguration.BuildingViewPrefab);

                if (!_constructionGridManager.TryPlaceStructureAt(structure, cell))
                {
                    UnityEngine.Object.Destroy(structure.View.gameObject);
                    return false;
                }

                ShowPlacementValidityAt(cell);
                _structurePlacedCallback.Invoke(structure);
                return true;
            }
        }

        public void FinishAction()
        {

        }

        public void ExitState()
        {
            HidePlacementPreview();
            HidePlacementCells();

            void HidePlacementPreview()
            {
                UnityEngine.Object.Destroy(_previewObject);
                _preview = null;
            }

            void HidePlacementCells()
            {
                _placementCellsVisualization.DestroyVisualization();
            }
        }

        public void RotateBuilding()
        {
            ChangeOrientation();
            ShowPlacementCellsAt(_currentCell);
            ShowPlacementValidityAt(_currentCell);

            void ChangeOrientation()
            {
                EOrientation newOrientation = OrientationOperations.RotateClockwise(_structureLayout.Orientation);
                _structureLayout.Orientation = newOrientation;
                _preview.SetOrientation(newOrientation);
            }
        }

        private void ShowPlacementAt(Vector2Int cell)
        {
            ShowPlacementPreviewAt(cell);
            ShowPlacementCellsAt(cell);
            ShowPlacementValidityAt(cell);

            void ShowPlacementPreviewAt(Vector2Int cell)
            {
                _preview.MoveToCell(cell);
            }
        }

        private void ShowPlacementCellsAt(Vector2Int originCell)
        {
            Vector2Int[] placementCells = GetPlacementCells(originCell);
            _placementCellsVisualization.CreateVisualization(placementCells);

            Vector2Int[] GetPlacementCells(Vector2Int originCell)
            {
                _placementCells.Clear();

                foreach (var cell in _structureLayout.OccupiedCells)
                {
                    Vector2Int placementCell = originCell + cell;
                    _placementCells.Add(placementCell);
                }

                return _placementCells.ToArray();
            }
        }

        private void ShowPlacementValidityAt(Vector2Int cell)
        {
            if (CheckIfCanPlaceLayoutAt(cell))
            {
                ShowValidPlacement();
            }
            else
            {
                ShowInvalidPlacement();
            }

            bool CheckIfCanPlaceLayoutAt(Vector2Int cell)
            {
                return _constructionGridManager.CheckIfCanPlaceLayoutAt(cell, _structureLayout.OccupiedCells);
            }

            void ShowValidPlacement()
            {
                _preview.ShowValidPlacement();
            }

            void ShowInvalidPlacement()
            {
                _preview.ShowInvalidPlacement();
            }
        }
    }
}