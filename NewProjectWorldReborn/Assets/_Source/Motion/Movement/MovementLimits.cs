using System;
using UnityEngine;

namespace Movement
{
    [Serializable]
    internal class MovementLimits
    {
        [SerializeField] private float frontBorder;
        [SerializeField] private float backBorder;
        [SerializeField] private float rightBorder;
        [SerializeField] private float leftBorder;

        public float FrontBorder { get { return frontBorder; } }
        public float BackBorder { get { return backBorder; } }
        public float RightBorder { get { return rightBorder; } }
        public float LeftBorder { get { return leftBorder; } }
    }
}
