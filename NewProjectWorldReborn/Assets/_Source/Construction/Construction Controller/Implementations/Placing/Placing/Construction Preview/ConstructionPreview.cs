using CustomUtilities.RendererUtilities;
using LayoutSystem;
using System;
using UnityEngine;

namespace PlacingSystem
{
    public class ConstructionPreview
    {
        private readonly Transform _previewTransform;
        private readonly Grid _grid;
        private readonly Material _validPlacementMaterial;
        private readonly Material _invalidPlacementMaterial;

        private readonly MultipleRenderersMaterialsSwitcher _materialsSwitcher;

        public ConstructionPreview(GameObject previewObject,
                                   Grid grid,
                                   Material validPlacementMaterial,
                                   Material invalidPlacementMaterial)
        {
            _grid = grid != null ? grid : throw new ArgumentNullException(nameof(grid));
            _validPlacementMaterial = validPlacementMaterial != null ? validPlacementMaterial : throw new ArgumentNullException(nameof(validPlacementMaterial));
            _invalidPlacementMaterial = invalidPlacementMaterial != null ? invalidPlacementMaterial : throw new ArgumentNullException(nameof(invalidPlacementMaterial));

            _previewTransform = previewObject.transform;
            _materialsSwitcher = new(previewObject);
        }

        public void ShowValidPlacement()
        {
            _materialsSwitcher?.SwitchMaterialsWithMaterial(_validPlacementMaterial);
        }

        public void ShowInvalidPlacement()
        {
            _materialsSwitcher?.SwitchMaterialsWithMaterial(_invalidPlacementMaterial);
        }

        public void MoveToCell(Vector2Int cell)
        {
            Vector3Int cellPosition = new(cell.x, 0, cell.y);
            Vector3 worldPosition = _grid.CellToWorld(cellPosition);
            Vector3 offset = _grid.cellSize / 2;
            _previewTransform.position = worldPosition + offset;
        }

        public void SetOrientation(EOrientation orientation)
        {
            _previewTransform.localRotation = OrientationOperations.GetRotation(orientation);
        }
    }
}