using TMPro;
using UnityEngine;

namespace ResourceSystem.Implementations
{
    public class ResourceNameDisplayerMB : AResourceDisplayerMB
    {
        [SerializeField] private TextMeshProUGUI nameText;

        public override void DisplayResource(IResourceDefinition resource)
        {
            nameText.text = resource.Name;
        }

        public override void Clear()
        {
            nameText.text = "-";
        }
    }
}