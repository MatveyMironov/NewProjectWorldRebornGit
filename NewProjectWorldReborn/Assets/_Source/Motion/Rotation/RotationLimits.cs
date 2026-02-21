using System;
using UnityEngine;

namespace Rotation
{
    [Serializable]
    internal class RotationLimits
    {
        [SerializeField] float maxXAngle;
        [SerializeField] float minXAngle;

        public float MaxXAngle { get { return maxXAngle; } }
        public float MinXAngle { get { return minXAngle; } }
    }
}
