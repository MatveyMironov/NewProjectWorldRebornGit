using BuildingViewSystem;
using UnityEngine;

namespace PlacingSystem
{
    public class ConstructionPreviewFactoryMB : MonoBehaviour, IConstructionPreviewFactory
    {
        [SerializeField] private Transform constructionPreviewParent;
        [SerializeField] private Grid grid;

        [Header("Materials Switch")]
        [SerializeField] private Material validPlacementMaterial;
        [SerializeField] private Material invalidPlacementMaterial;

        public ConstructionPreview CreateConstructionPreview(GameObject previewObject)
        {
            previewObject.transform.SetParent(constructionPreviewParent);
            return new(previewObject, grid, validPlacementMaterial, invalidPlacementMaterial);
        }
    }
}