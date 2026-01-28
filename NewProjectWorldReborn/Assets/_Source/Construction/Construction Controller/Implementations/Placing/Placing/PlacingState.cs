using LayoutSystem;
using ConstructionGridSystem;
using PlacingSystem;
using CellsVisualizationSystem;
using System;
using System.Collections.Generic;
using UnityEngine;
using ConstructionControllerSystem;
using BuildingViewSystem;
using System.Linq;

namespace PlacingSystem
{
    public class PlacingState : IConstructionState
    {
        private readonly IConstructionConfiguration _constructionConfiguration;

        private readonly IConstructionGridManager _constructionGridManager;
        private readonly IConstructionPreviewController _preview;
        private readonly ICellsVisualization _placementCellsVisualization;
        private readonly IBuildingViewInstantiator _buildingViewInstantiator;

        public PlacingState(IConstructionConfiguration constructionConfiguration,
                            IConstructionGridManager constructionGridManager,
                            IConstructionPreviewController preview,
                            ICellsVisualization placementCellsVisualization,
                            IBuildingViewInstantiator buildingViewInstantiator)
        {
            _constructionConfiguration = constructionConfiguration ?? throw new ArgumentNullException(nameof(constructionConfiguration));
            _constructionGridManager = constructionGridManager ?? throw new ArgumentNullException(nameof(constructionGridManager));
            _preview = preview ?? throw new ArgumentNullException(nameof(preview));
            _placementCellsVisualization = placementCellsVisualization ?? throw new ArgumentNullException(nameof(placementCellsVisualization));
            _buildingViewInstantiator = buildingViewInstantiator ?? throw new ArgumentNullException(nameof(buildingViewInstantiator));
        }

        private Vector2Int _currentCell;

        private Layout _buildingOccupation;
        private EOrientation _buildingOrientation;

        private readonly HashSet<Vector2Int> _placementCells = new();

        public event Action<BuildingStructure> OnBuildingPlaced;

        public void EnterState(Vector2Int cell)
        {
            CreateBuildingPreview(cell);

            _currentCell = cell;
        }

        public void UpdateState(Vector2Int cell)
        {
            _preview.MoveToCell(cell);

            ShowPlacementCells(cell);
            ShowPlacementValidity(cell);

            _currentCell = cell;
        }

        public void StartAction(Vector2Int cell)
        {
            _currentCell = cell;
        }

        public void FinishAction(Vector2Int cell)
        {
            if (_constructionGridManager.CheckIfCanPlaceBuilding(cell, _buildingOccupation.OccupiedCells))
            {
                BuildingViewMB buildingView = _buildingViewInstantiator.InstantiateBuildingView(_constructionConfiguration, cell, _buildingOrientation);
                BuildingStructure structure = new(buildingView, _buildingOccupation);

                if (_constructionGridManager.TryPlaceBuilding(structure, cell))
                {
                    _preview.HidePreview();

                    OnBuildingPlaced?.Invoke(structure);
                    _buildingOccupation = null;

                    CreateBuildingPreview(cell);
                }
                else
                {
                    UnityEngine.Object.Destroy(buildingView.gameObject);
                }
            }

            _currentCell = cell;
        }

        public void ExitState()
        {
            _preview.HidePreview();
            HidePlacementCells();
            _buildingOccupation = null;
        }

        private void CreateBuildingPreview(Vector2Int cell)
        {
            _buildingOccupation = new(_constructionConfiguration.OccupiedCells)
            {
                Orientation = _buildingOrientation
            };

            _preview.ShowPreview(_constructionConfiguration.ConstructionPreviewPrefab);
            _preview.MoveToCell(cell);

            ShowPlacementCells(cell);
            ShowPlacementValidity(cell);
        }

        public void RotateBuilding()
        {
            switch (_buildingOrientation)
            {
                case EOrientation.up:
                _buildingOrientation = EOrientation.right;
                break;

                case EOrientation.right:
                _buildingOrientation = EOrientation.down;
                break;

                case EOrientation.down:
                _buildingOrientation = EOrientation.left;
                break;

                case EOrientation.left:
                _buildingOrientation = EOrientation.up;
                break;
            }

            _buildingOccupation.Orientation = _buildingOrientation;
            _preview.SetOrientation(_buildingOrientation);
            ShowPlacementCells(_currentCell);
            ShowPlacementValidity(_currentCell);
        }

        private void ShowPlacementCells(Vector2Int originCell)
        {
            if (_buildingOccupation == null) return;

            _placementCells.Clear();
            foreach (var cell in _buildingOccupation.OccupiedCells)
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

        private void ShowPlacementValidity(Vector2Int originCell)
        {
            if (_constructionGridManager.CheckIfCanPlaceBuilding(originCell, _buildingOccupation.OccupiedCells))
            {
                _preview.ShowValidPlacement();
            }
            else
            {
                _preview.ShowInvalidPlacement();
            }
        }
    }
}