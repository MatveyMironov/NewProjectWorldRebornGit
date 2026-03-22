using UnityEngine;

namespace Zoom
{
    public class ZoomControllerMB : MonoBehaviour, IZoomController
    {
        [SerializeField] private ZoomParameters zoomParameters;
        [SerializeField] private ZoomLimits zoomLimits;

        private float _zoomAmount;

        private void Update()
        {
            if (_zoomAmount > 0)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, zoomLimits.MaxZoom, zoomParameters.ZoomSpeed * Time.deltaTime);
            }
            else if (_zoomAmount < 0)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, zoomLimits.MinZoom, zoomParameters.ZoomSpeed * Time.deltaTime);
            }
        }

        public void Zoom(float zoomAmount)
        {
            _zoomAmount = zoomAmount;
        }
    }
}