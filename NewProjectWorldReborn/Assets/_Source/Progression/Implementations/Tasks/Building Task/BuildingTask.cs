using BuildingSystem;
using CustomInfoSystem;
using System;
using UnityEngine;

namespace ProgressionSystem.Implementations
{
    public class BuildingTask : ITask
    {
        public IBuildingConfiguration RequiredBuildingConfiguration { get; }
        public int RequiredCount { get; }

        private readonly IConfigurationBuildingsManager _configurationBuildingsManager;

        public BuildingTask(IBuildingConfiguration requiredBuildingConfiguration,
                            int requiredCount,
                            IConfigurationBuildingsManager configurationBuildingsManager,
                            BuildingTaskDisplayerMB displayerPrefab)
        {
            RequiredBuildingConfiguration = requiredBuildingConfiguration ?? throw new ArgumentNullException(nameof(requiredBuildingConfiguration));
            RequiredCount = requiredCount;
            _configurationBuildingsManager = configurationBuildingsManager ?? throw new ArgumentNullException(nameof(configurationBuildingsManager));

            Info = new BuildingTaskInfo(this, displayerPrefab);

            Setup();

            void Setup()
            {
                _configurationBuildingsManager.OnBuildingAdded += CompleteIsPossible;
                _configurationBuildingsManager.OnBuildingRemoved += CompleteIsPossible;

                CompleteIfPossible();
            }

            void CompleteIsPossible(Building building)
            {
                Debug.Log(1);

                if (building.Configuration == RequiredBuildingConfiguration)
                {
                    OnActualCountChanged?.Invoke();
                    CompleteIfPossible();
                }
            }

            void CompleteIfPossible()
            {
                if (IsCompleted)
                {
                    _configurationBuildingsManager.OnBuildingAdded -= CompleteIsPossible;
                    _configurationBuildingsManager.OnBuildingRemoved -= CompleteIsPossible;

                    OnCompleted?.Invoke();
                }
            }
        }

        public bool IsCompleted { get { return ActualCount >= RequiredCount; } }
        public event Action OnCompleted;

        public ICustomInfo Info { get; }

        public int ActualCount { get { return _configurationBuildingsManager.GetBuildingCount(RequiredBuildingConfiguration); } }
        public event Action OnActualCountChanged;
    }
}