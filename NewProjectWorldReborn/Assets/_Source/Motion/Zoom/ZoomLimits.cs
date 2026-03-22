using System;
using UnityEngine;

namespace Zoom
{
    [Serializable]
    internal class ZoomLimits
    {
        [SerializeField] private Vector3 minZoom;
        [SerializeField] private Vector3 maxZoom;

        public Vector3 MinZoom { get { return minZoom; } }
        public Vector3 MaxZoom { get { return maxZoom; } }
    }
}
