using UnityEngine;
using UnityEngine.EventSystems;

namespace ServiceSystem.Implementations
{
    public class PointerHandlerServiceDefinitionDisplayerMB : AServiceDefinitionDisplayerMB, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private AServiceDefinitionDisplayerMB actualdisplayer;

        private IServiceDefinition _displayedService;
        private bool _isPointerOver;

        public override void Clear()
        {
            _displayedService = null;

            actualdisplayer.Clear();
        }

        public override void DisplayServiceDefinition(IServiceDefinition service)
        {
            _displayedService = service;

            if (_isPointerOver)
            {
                actualdisplayer.DisplayServiceDefinition(service);
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            _isPointerOver = true;

            if (_displayedService == null) { return; }

            actualdisplayer.DisplayServiceDefinition(_displayedService);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isPointerOver = false;

            actualdisplayer.Clear();
        }
    }
}