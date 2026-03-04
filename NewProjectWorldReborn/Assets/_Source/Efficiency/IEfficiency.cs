using System;

namespace EfficiencySystem
{
    public interface IEfficiency
    {
        public float Efficiency { get; }

        public event Action OnEfficiencyChanged;
    }
}
