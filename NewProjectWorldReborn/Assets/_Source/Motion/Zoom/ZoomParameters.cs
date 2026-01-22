using System;
using UnityEngine;

namespace Zoom
{
    [Serializable]
    internal class ZoomParameters
    {
        [SerializeField] private float zoomSpeed;

        public float ZoomSpeed { get { return zoomSpeed; } }
    }
}
