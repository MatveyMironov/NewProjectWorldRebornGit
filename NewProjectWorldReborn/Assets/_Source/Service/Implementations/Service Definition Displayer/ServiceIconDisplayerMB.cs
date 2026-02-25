using UnityEngine;
using UnityEngine.UI;

namespace ServiceSystem.Implementations
{
    public class ServiceIconDisplayerMB : AServiceDefinitionDisplayerMB
    {
        [SerializeField] private Image serviceIconImage;

        public override void DisplayServiceDefinition(IServiceDefinition service)
        {
            serviceIconImage.sprite = service.Icon;
        }

        public override void Clear()
        {
            serviceIconImage.sprite = null;
        }
    }
}