using TMPro;
using UnityEngine;

namespace ServiceSystem.Implementations
{
    public class TextServiceNameDisplayerMB : AServiceDefinitionDisplayerMB
    {
        [SerializeField] private TextMeshProUGUI serviceNameText;

        public override void DisplayServiceDefinition(IServiceDefinition service)
        {
            serviceNameText.text = service.Name;
        }

        public override void Clear()
        {
            serviceNameText.text = string.Empty;
        }
    }
}