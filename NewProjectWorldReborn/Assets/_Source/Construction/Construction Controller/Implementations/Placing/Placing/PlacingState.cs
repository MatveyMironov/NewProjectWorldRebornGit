using LayoutSystem;
using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using ConstructionControllerSystem;
using System.Linq;

namespace PlacingSystem
{
    public class PlacingState : IConstructionState
    {
        private readonly IConstructionConfiguration _constructionConfiguration;

        private readonly IConstructionGridManager _constructionGridManager;
        private readonly IConstructionPreviewController _previewController;
        private readonly ICellsVisualization _placementCellsVisualization;
        private readonly IBuildingStructureCreator _buildingViewInstantiator;

        private readonly Layout _buildingLayout;

        public PlacingState(IConstructionConfiguration constructionConfiguration,
                            IConstructionGridManager constructionGridManager,
                            IConstructionPreviewController preview,
                            ICellsVisualization placementCellsVisualization,
                            IBuildingStructureCreator buildingViewInstantiator)
        {
            _constructionConfiguration = constructionConfiguration ?? throw new ArgumentNullException(nameof(constructionConfiguration));
            _constructionGridManager = constructionGridManager ?? throw new ArgumentNullException(nameof(constructionGridManager));
            _previewController = preview ?? throw new ArgumentNullException(nameof(preview));
            _placementCellsVisualization = placementCellsVisualization ?? throw new ArgumentNullException(nameof(placementCellsVisualization));
            _buildingViewInstantiator = buildingViewInstantiator ?? throw new ArgumentNullException(nameof(buildingViewInstantiator));

            _buildingLayout = new(_constructionConfiguration.OccupiedCells);
        }

        private Vector2Int _currentCell;

        //Cashing hash set for perfomance
        private readonly HashSet<Vector2Int> _placementCells = new();

        public event Action<BuildingStructure> OnBuildingPlaced;

        public void EnterState(Vector2Int cell)
        {
            _currentCell = cell;

            //Show player where structure will be placed
            _previewController.ShowPreview(_constructionConfiguration.ConstructionPreviewPrefab);
            _previewController.SetOrientation(_buildingLayout.Orientation);
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
                BuildingStructure structure = _buildingViewInstantiator.CreateBuildingStructure(_constructionConfiguration, cell, _buildingLayout.Orientation);

                if (_constructionGridManager.TryPlaceStructureAt(structure, cell))
                {
                    OnBuildingPlaced?.Invoke(structure);

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
            HidePlacement();
        }

        private void ShowPlacementAt(Vector2Int cell)
        {
            _previewController.MoveToCell(cell);
            ShowPlacementCellsAt(cell);
            ShowPlacementValidityAt(cell);
        }

        private void HidePlacement()
        {
            _previewController.HidePreview();
            HidePlacementCells();
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

            _previewController.SetOrientation(_buildingLayout.Orientation);
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
                _previewController.ShowValidPlacement();
            }

            void ShowInvalidPlacement()
            {
                _previewController.ShowInvalidPlacement();
            }
        }
    }
}