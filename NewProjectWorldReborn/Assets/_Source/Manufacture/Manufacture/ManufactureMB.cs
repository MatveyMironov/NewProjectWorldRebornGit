using ResourceSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ManufactureSystem
{
    public class ManufactureMB : MonoBehaviour, IManufacture
    {
        [SerializeField] private SManufactureConfiguration configuration;

        private IManufacture _manufacture;

        private void Awake()
        {
            _manufacture = configuration.CreateManufacture();
        }

        public Dictionary<IResourceDefinition, int> ConsumedResources => _manufacture.ConsumedResources;
        public event Func<Dictionary<IResourceDefinition, int>, bool> OnConsumptionRequested { add => _manufacture.OnConsumptionRequested += value; remove => _manufacture.OnConsumptionRequested -= value; }
        public Dictionary<IResourceDefinition, int> ProducedResources => _manufacture.ProducedResources;
        public event Func<Dictionary<IResourceDefinition, int>, bool> OnProductionRequested { add => _manufacture.OnProductionRequested += value; remove => _manufacture.OnProductionRequested -= value; }

        public int ManufactureTime => _manufacture.ManufactureTime;

        public bool IsStarted => _manufacture.IsStarted;
        public bool IsPossible => _manufacture.IsPossible;

        public bool IsPaused => _manufacture.IsPaused;
        public event Action OnPaused { add => _manufacture.OnPaused += value; remove => _manufacture.OnPaused -= value; }
        public event Action OnResumed { add => _manufacture.OnResumed += value; remove => _manufacture.OnResumed -= value; }

        public float Progress => _manufacture.Progress;
        public event Action OnProgressChanged { add => _manufacture.OnProgressChanged += value; remove => _manufacture.OnProgressChanged -= value; }

        public void AbortManufacture()
        {
            _manufacture.AbortManufacture();
        }

        public void ProgressManufacture()
        {
            _manufacture.ProgressManufacture();
        }

        public void StartManufacture()
        {
            _manufacture.StartManufacture();
        }

        public bool TryPause()
        {
            return _manufacture.TryPause();
        }

        public bool TryResume()
        {
            return _manufacture.TryResume();
        }
    }
}