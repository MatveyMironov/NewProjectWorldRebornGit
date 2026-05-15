using TMPro;
using UnityEngine;

namespace ServiceSystem.Implementations
{
    public class TextServiceDescriptionDisplayerMB : AServiceDefinitionDisplayerMB
    {
        [SerializeField] private TextMeshProUGUI serviceDescriptionText;

        public override void DisplayServiceDefinition(IServiceDefinition service)
        {
            serviceDescriptionText.text = service.ServiceDescription;
        }

        public override void Clear()
        {
            serviceDescriptionText.text = string.Empty;
        }
    }
}