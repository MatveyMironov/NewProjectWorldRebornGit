using EfficiencySystem;
using ResourceSystem;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ManufactureSystem
{
    public class ManufactureMB : MonoBehaviour, IManufacture
    {
        [SerializeField] private SManufactureConfiguration configuration;
        [SerializeField] private AEfficiencyConfigurationSO efficiencyConfiguration;

        private IManufacture _manufacture;

        private void Awake()
        {
            _manufacture = configuration.CreateManufacture(efficiencyConfiguration.GetEfficiency());
        }

        public int MinTime => _manufacture.MinTime;

        public Dictionary<IResourceDefinition, int> ConsumedResources => _manufacture.ConsumedResources;
        public Dictionary<IResourceDefinition, int> ProducedResources => _manufacture.ProducedResources;

        public bool IsPaused { get => _manufacture.IsPaused; set => _manufacture.IsPaused = value; }

        public event Action OnPaused
        {
            add => _manufacture.OnPaused += value;
            remove => _manufacture.OnPaused -= value;
        }

        public event Action OnUnpaused
        {
            add => _manufacture.OnUnpaused += value;
            remove => _manufacture.OnUnpaused -= value;
        }

        public bool IsStarted => _manufacture.IsStarted;
        public bool IsPossible => _manufacture.IsPossible;
        public float ManufactureTime => _manufacture.ManufactureTime;

        public float Efficiency => _manufacture.Efficiency;
        public event Action OnEfficicencyChanged
        {
            add => _manufacture.OnEfficicencyChanged += value;
            remove => _manufacture.OnEfficicencyChanged -= value;
        }

        public float Progress => _manufacture.Progress;
        public event Action OnProgressChanged
        {
            add => _manufacture.OnProgressChanged += value;
            remove => _manufacture.OnProgressChanged -= value;
        }

        public event Func<Dictionary<IResourceDefinition, int>, bool> OnConsumptionRequested
        {
            add => _manufacture.OnConsumptionRequested += value;
            remove => _manufacture.OnConsumptionRequested -= value;
        }

        public event Func<Dictionary<IResourceDefinition, int>, bool> OnProductionRequested
        {
            add => _manufacture.OnProductionRequested += value;
            remove => _manufacture.OnProductionRequested -= value;
        }

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
    }
}