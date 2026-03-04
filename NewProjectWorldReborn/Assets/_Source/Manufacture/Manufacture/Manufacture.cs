using ResourceSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ManufactureSystem
{
    public class Manufacture : IManufacture
    {
        private readonly ManufactureParameters _manufactureParameters;

        internal Manufacture(ManufactureParameters manufactureParameters)
        {
            _manufactureParameters = manufactureParameters ?? throw new ArgumentNullException(nameof(manufactureParameters));
        }

        public Dictionary<IResourceDefinition, int> ConsumedResources => _manufactureParameters.ConsumedResources;
        public event Func<Dictionary<IResourceDefinition, int>, bool> OnConsumptionRequested;

        public Dictionary<IResourceDefinition, int> ProducedResources => _manufactureParameters.ProducedResources;
        public event Func<Dictionary<IResourceDefinition, int>, bool> OnProductionRequested;

        public int ManufactureTime => _manufactureParameters.MinTime;

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

        public bool IsPossible => IsStarted && !IsPaused;

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