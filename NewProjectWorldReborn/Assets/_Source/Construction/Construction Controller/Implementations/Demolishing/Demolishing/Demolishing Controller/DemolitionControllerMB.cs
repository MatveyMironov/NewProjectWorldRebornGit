using ConstructionControllerSystem;
using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;
using UnityEngine;

namespace DemolishingSystem
{
    public class DemolitionControllerMB : MonoBehaviour, IDemolitionController
    {
        [SerializeField] private ConstructionControllerMB constructionController;
        [SerializeField] private ConstructionGridManagerMB constructionGridManager;
        [SerializeField] private ACellsVisualizationMB demolitionGridVisualization;

        private IDemolitionController _controller;

        private void Awake()
        {
            _controller = new DemolitionController(constructionController, constructionGridManager, demolitionGridVisualization);
        }

        public event Action OnBuildingSelected
        {
            add => _controller.OnBuildingSelected += value;
            remove => _controller.OnBuildingSelected -= value;
        }

        public event Action OnBuildingDeselected
        {
            add => _controller.OnBuildingDeselected += value;
            remove => _controller.OnBuildingDeselected -= value;
        }

        public event Action<BuildingStructure> OnBuildingDemolished
        {
            add => _controller.OnBuildingDemolished += value;
            remove => _controller.OnBuildingDemolished -= value;
        }

        public event Action OnStateEntered
        {
            add => _controller.OnStateEntered += value;
            remove => _controller.OnStateEntered -= value;
        }

        public event Action OnStateExited
        {
            add => _controller.OnStateExited += value;
            remove => _controller.OnStateExited -= value;
        }

        public void StartDemolishing()
        {
            _controller.StartDemolishing();
        }
    }
}