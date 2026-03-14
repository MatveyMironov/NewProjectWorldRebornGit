using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ServiceSystem.Implementations
{
    public class DefaultServiceDefinitionDisplayerMB : AServiceDefinitionDisplayerMB
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI nameText;

        public override void DisplayServiceDefinition(IServiceDefinition service)
        {
            iconImage.sprite = service.Icon;
            nameText.text = service.Name;
        }

        public override void Clear()
        {
            iconImage.sprite = null;
            nameText.text = "";
        }
    }
}