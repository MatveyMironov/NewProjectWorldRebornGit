using UnityEngine;
using UnityEngine.EventSystems;

namespace ResourceSystem.Implementations
{
    public class PointerHandlerResourceDisplayerMB : AResourceDisplayerMB, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private AResourceDisplayerMB resourceDisplayer;

        private IResourceDefinition _displayedResource;

        public override void DisplayResource(IResourceDefinition resource)
        {
            _displayedResource = resource;
        }

        public override void Clear()
        {
            _displayedResource = null;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            //Debug.Log("Pointer Enter");

            if (_displayedResource == null) { return; }

            resourceDisplayer.DisplayResource(_displayedResource);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //Debug.Log("Pointer Exit");
            resourceDisplayer.Clear();
        }
    }
}