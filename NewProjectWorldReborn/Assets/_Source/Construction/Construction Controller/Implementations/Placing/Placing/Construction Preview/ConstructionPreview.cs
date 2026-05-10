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

            _previewTransform.position = worldPosition + _grid.cellSize / 2;
        }

        public void SetOrientation(EOrientation orientation)
        {
            switch (orientation)
            {
                case EOrientation.up:
                _previewTransform.localRotation = Quaternion.Euler(0, 0, 0);
                break;

                case EOrientation.right:
                _previewTransform.localRotation = Quaternion.Euler(0, 90, 0);
                break;

                case EOrientation.down:
                _previewTransform.localRotation = Quaternion.Euler(0, 180, 0);
                break;

                case EOrientation.left:
                _previewTransform.localRotation = Quaternion.Euler(0, 270, 0);
                break;
            }
        }
    }
}