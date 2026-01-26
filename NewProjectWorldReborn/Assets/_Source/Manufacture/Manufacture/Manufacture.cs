using EfficiencySystem;
using ResourceSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ManufactureSystem
{
    public class Manufacture : IManufacture
    {
        private readonly ManufactureParameters _manufactureParameters;
        private readonly IEfficiency _efficiency;

        internal Manufacture(ManufactureParameters manufactureParameters, IEfficiency efficiency)
        {
            _manufactureParameters = manufactureParameters ?? throw new ArgumentNullException(nameof(manufactureParameters));
            _efficiency = efficiency ?? throw new ArgumentNullException(nameof(efficiency));
        }

        public Dictionary<IResourceDefinition, int> ConsumedResources => _manufactureParameters.ConsumedResources;
        public event Func<Dictionary<IResourceDefinition, int>, bool> OnConsumptionRequested;

        public Dictionary<IResourceDefinition, int> ProducedResources => _manufactureParameters.ProducedResources;
        public event Func<Dictionary<IResourceDefinition, int>, bool> OnProductionRequested;

        public int MinTime => _manufactureParameters.MinTime;
        public float Efficiency => _efficiency.Efficiency;

        public event Action OnEfficicencyChanged
        {
            add => _efficiency.OnEfficiencyChanged += value;
            remove => _efficiency.OnEfficiencyChanged -= value;
        }

        #region Pause
        public bool _isManufacturePaused;
        public event Action OnPaused;
        public event Action OnUnpaused;

        public bool IsPaused
        {
            get { return _isManufacturePaused; }
            set
            {
                if (_isManufacturePaused = value) return;
                _isManufacturePaused = value;

                if (_isManufacturePaused)
                {
                    OnPaused?.Invoke();
                }
                else
                {
                    OnUnpaused?.Invoke();
                }
            }
        }
        #endregion

        public bool IsStarted { get; private set; }

        public bool IsPossible => IsStarted && Efficiency > 0 && !IsPaused;

        public float ManufactureTime => MinTime / Efficiency;

        #region Progress
        private float _progress;
        public event Action OnProgressChanged;
        public float Progress
        {
            get { return _progress; }
            set
            {
                _progress = value;
                OnProgressChanged?.Invoke();
            }
        }
        #endregion

        public void StartManufacture()
        {
            if (IsStarted) return;
            IsStarted = true;
        }

        public void AbortManufacture()
        {
            if (!IsStarted) return;
            IsStarted = false;

            Progress = 0.0f;
        }

        public void ProgressManufacture()
        {
            if (!IsPossible) return;

            Progress += Time.deltaTime / ManufactureTime;

            if (Progress >= 1.0f)
            {
                if (TryConsume())
                {
                    Progress -= 1.0f;
                    TryProduce();
                }
            }
        }

        public bool TryConsume()
        {
            return (bool)(OnConsumptionRequested?.Invoke(ConsumedResources));
        }

        public bool TryProduce()
        {
            return (bool)OnProductionRequested?.Invoke(ProducedResources);
        }
    }
}