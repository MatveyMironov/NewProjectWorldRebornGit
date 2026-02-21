using System;
using UnityEngine;

namespace Movement
{
    [Serializable]
    internal class MovementParameters
    {
        [SerializeField] private float defaultSpeed;
        [SerializeField] private float increasedSpeed;

        public bool IsSpeedIncreased { get; set; }

        public float Speed
        {
            get
            {
                if (IsSpeedIncreased)
                {
                    return increasedSpeed;
                }

                return defaultSpeed;
            }
        }
    }
}
