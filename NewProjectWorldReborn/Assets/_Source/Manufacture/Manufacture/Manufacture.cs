using ResourceSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ManufactureSystem
{
    public class Manufacture : IManufacture
    {
        private readonly IManufactureParameters _manufactureParameters;

        public Manufacture(IManufactureParameters manufactureParameters)
        {
            _manufactureParameters = manufactureParameters ?? throw new ArgumentNullException(nameof(manufactureParameters));
        }

        public Dictionary<IResourceDefinition, int> ConsumedResources => _manufactureParameters.ConsumedResources;
        public event Func<Dictionary<IResourceDefinition, int>, bool> OnConsumptionRequested;

        public Dictionary<IResourceDefinition, int> ProducedResources => _manufactureParameters.ProducedResources;
        public event Func<Dictionary<IResourceDefinition, int>, bool> OnProductionRequested;

        public float Speed => _manufactureParameters.Speed;

        public bool IsStarted { get; private set; }
        public bool IsPossible => IsStarted && !IsPaused;

        public bool IsPaused { get; private set; }
        public event Action OnPaused;
        public event Action OnResumed;

        public float Progress { get; private set; }
        public event Action OnProgressChanged;

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
            OnProgressChanged?.Invoke();
        }

        public void ProgressManufacture()
        {
            if (!IsPossible) return;

            Progress += Time.deltaTime * Speed;
            OnProgressChanged?.Invoke();

            if (Progress >= 1.0f)
            {
                if (TryConsume())
                {
                    Progress -= 1.0f;
                    OnProgressChanged?.Invoke();
                    TryProduce();
                }
                else
                {
                    Progress = 1.0f;
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

        public bool TryPause()
        {
            if (IsPaused) return false;

            IsPaused = true;
            OnPaused?.Invoke();
            return true;
        }

        public bool TryResume()
        {
            if (!IsPaused) return false;

            IsPaused = false;
            OnResumed?.Invoke();
            return true;
        }
    }
}