using TMPro;
using UnityEngine;

namespace ResourceSystem.Implementations
{
    public class TextResourceCountDisplayerMB : AResourceCountDisplayerMB
    {
        [SerializeField] private AResourceDisplayerMB resourceDisplayer;
        [SerializeField] private TextMeshProUGUI countText;

        public override void DisplayResource(IResourceDefinition resource)
        {
            resourceDisplayer.DisplayResource(resource);
        }

        public override void DisplayCount(int count)
        {
            countText.text = count.ToString();
        }
    }
}