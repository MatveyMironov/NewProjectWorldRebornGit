using System;
using UnityEngine;

namespace Rotation
{
    [Serializable]
    internal class RotationInputParameters
    {
        [SerializeField] private float xAxisSensetivity;
        [SerializeField] private float yAxisSensetivity;

        [SerializeField] private bool invertXAxis;
        [SerializeField] private bool invertYAxis;

        public float XRotationFactor
        {
            get
            {
                return invertYAxis ? -yAxisSensetivity : yAxisSensetivity;
            }
        }

        public float YRotationFactor
        {
            get
            {
                return invertXAxis ? -xAxisSensetivity : xAxisSensetivity;
            }
        }
    }
}
