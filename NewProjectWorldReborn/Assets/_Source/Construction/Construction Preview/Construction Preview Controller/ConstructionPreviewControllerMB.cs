using CustomUtilities.RendererUtilities;
using LayoutSystem;
using UnityEngine;

namespace ConstructionPreviewSystem
{
    public class ConstructionPreviewControllerMB : MonoBehaviour, IConstructionPreviewController
    {
        [SerializeField] private Transform constructionPreviewParent;
        [SerializeField] private Grid grid;

        [Header("Materials Switch")]
        [SerializeField] private Material validPlacementMaterial;
        [SerializeField] private Material invalidPlacementMaterial;

        private ConstructionPreviewMB _constructionPreview;
        private MultipleRenderersMaterialsSwitcher _materialsSwitcher;

        public void ShowValidPlacement()
        {
            _materialsSwitcher?.SwitchMaterialsWithMaterial(validPlacementMaterial);
        }

        public void ShowInvalidPlacement()
        {
            _materialsSwitcher?.SwitchMaterialsWithMaterial(invalidPlacementMaterial);
        }

        public void MoveToCell(Vector2Int cell)
        {
            Vector3Int cellPosition = new(cell.x, 0, cell.y);
            Vector3 worldPosition = grid.CellToWorld(cellPosition);

            constructionPreviewParent.position = worldPosition + grid.cellSize / 2;
        }

        public void SetOrientation(EOrientation orientation)
        {
            switch (orientation)
            {
                case EOrientation.up:
                constructionPreviewParent.localRotation = Quaternion.Euler(0, 0, 0);
                break;

                case EOrientation.right:
                constructionPreviewParent.localRotation = Quaternion.Euler(0, 90, 0);
                break;

                case EOrientation.down:
                constructionPreviewParent.localRotation = Quaternion.Euler(0, 180, 0);
                break;

                case EOrientation.left:
                constructionPreviewParent.localRotation = Quaternion.Euler(0, 270, 0);
                break;
            }
        }

        public void ShowPreview(ConstructionPreviewMB prefab)
        {
            if (prefab == null) return;

            HidePreview();

            _constructionPreview = Instantiate(prefab, constructionPreviewParent);
            _materialsSwitcher = new(_constructionPreview.gameObject);
        }

        public void HidePreview()
        {
            if (_constructionPreview == null) return;

            Destroy(_constructionPreview.gameObject);
            _constructionPreview = null;
        }
    }
}