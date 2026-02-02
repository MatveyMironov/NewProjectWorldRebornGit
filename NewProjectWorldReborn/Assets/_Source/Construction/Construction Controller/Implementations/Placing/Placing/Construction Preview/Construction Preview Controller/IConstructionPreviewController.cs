using LayoutSystem;
using UnityEngine;

namespace PlacingSystem
{
    public interface IConstructionPreviewController
    {
        public void ShowValidPlacement();
        public void ShowInvalidPlacement();
        public void MoveToCell(Vector2Int cell);
        public void SetOrientation(EOrientation orientation);
        public void ShowPreview(ConstructionPreviewMB prefab);
        public void HidePreview();
    }
}