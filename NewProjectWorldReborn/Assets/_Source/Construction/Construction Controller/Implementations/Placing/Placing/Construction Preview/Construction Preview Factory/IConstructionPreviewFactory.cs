using UnityEngine;

namespace PlacingSystem
{
    public interface IConstructionPreviewFactory
    {
        public ConstructionPreview CreateConstructionPreview(GameObject previewObject);
    }
}