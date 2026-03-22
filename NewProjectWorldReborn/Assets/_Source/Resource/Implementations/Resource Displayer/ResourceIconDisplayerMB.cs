using UnityEngine;
using UnityEngine.UI;

namespace ResourceSystem.Implementations
{
    public class ResourceIconDisplayerMB : AResourceDisplayerMB
    {
        [SerializeField] private Image iconImage;

        public override void DisplayResource(IResourceDefinition resource)
        {
            iconImage.sprite = resource.Icon;
        }

        public override void Clear()
        {
            iconImage.sprite = null;
        }
    }
}