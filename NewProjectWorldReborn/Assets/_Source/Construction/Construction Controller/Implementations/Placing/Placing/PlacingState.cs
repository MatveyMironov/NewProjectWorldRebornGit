using LayoutSystem;
using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using ConstructionControllerSystem;
using System.Linq;
using BuildingViewSystem;

namespace PlacingSystem
{
    public class PlacingState : IConstructionState
    {
        private readonly IConstructionConfiguration _constructionConfiguration;

        private readonly IConstructionGridManager _constructionGridManager;
        private readonly IConstructionPreviewFactory _previewFactory;
        private readonly ICellsVisualization _placementCellsVisualization;
        private readonly IBuildingStructureFactory _structureFactory;
        private readonly Action<BuildingStructure> _structurePlacedCallback;

        private readonly Layout _buildingLayout;

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

            _buildingLayout = _constructionConfiguration.GetBuildingLayout();
        }

        private Vector2Int _currentCell;

        //Cashing hash set for perfomance
        private readonly HashSet<Vector2Int> _placementCells = new();

        private GameObject _previewObject;
        private ConstructionPreview _preview;

        public void EnterState(Vector2Int cell)
        {
            _currentCell = cell;

            _previewObject = _constructionConfiguration.CreateBuildingPreviewObject();
            _preview = _previewFactory.CreateConstructionPreview(_previewObject);
            _preview.SetOrientation(_buildingLayout.Orientation);
            ShowPlacementAt(cell);
        }

        public void UpdateState(Vector2Int cell)
        {
            _currentCell = cell;

            ShowPlacementAt(cell);
        }

        public void StartAction(Vector2Int cell)
        {
            _currentCell = cell;

            if (_constructionGridManager.CheckIfCanPlaceLayoutAt(cell, _buildingLayout.OccupiedCells))
            {
                BuildingStructure structure = _structureFactory.CreateBuildingStructure(cell, _buildingLayout, _constructionConfiguration.BuildingViewPrefab);

                if (_constructionGridManager.TryPlaceStructureAt(structure, cell))
                {
                    _structurePlacedCallback.Invoke(structure);

                    ShowPlacementValidityAt(cell);
                }
                else
                {
                    UnityEngine.Object.Destroy(structure.View.gameObject);
                }
            }
        }

        public void FinishAction(Vector2Int cell)
        {
            _currentCell = cell;
        }

        public void ExitState()
        {
            UnityEngine.Object.Destroy(_previewObject);
            HidePlacementCells();
        }

        private void ShowPlacementAt(Vector2Int cell)
        {
            _preview.MoveToCell(cell);
            ShowPlacementCellsAt(cell);
            ShowPlacementValidityAt(cell);
        }

        public void RotateBuilding()
        {
            switch (_buildingLayout.Orientation)
            {
                case EOrientation.up:
                _buildingLayout.Orientation = EOrientation.right;
                break;

                case EOrientation.right:
                _buildingLayout.Orientation = EOrientation.down;
                break;

                case EOrientation.down:
                _buildingLayout.Orientation = EOrientation.left;
                break;

                case EOrientation.left:
                _buildingLayout.Orientation = EOrientation.up;
                break;
            }

            _preview.SetOrientation(_buildingLayout.Orientation);
            ShowPlacementCellsAt(_currentCell);
            ShowPlacementValidityAt(_currentCell);
        }

        private void ShowPlacementCellsAt(Vector2Int originCell)
        {
            _placementCells.Clear();
            foreach (var cell in _buildingLayout.OccupiedCells)
            {
                Vector2Int placementCell = originCell + cell;
                _placementCells.Add(placementCell);
            }

            _placementCellsVisualization.CreateVisualization(_placementCells.ToArray());
        }

        private void HidePlacementCells()
        {
            _placementCellsVisualization.DestroyVisualization();
        }

        private void ShowPlacementValidityAt(Vector2Int originCell)
        {
            if (_constructionGridManager.CheckIfCanPlaceLayoutAt(originCell, _buildingLayout.OccupiedCells))
            {
                ShowValidPlacement();
            }
            else
            {
                ShowInvalidPlacement();
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