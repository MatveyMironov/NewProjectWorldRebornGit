using ConstructionControllerSystem;
using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;
using UnityEngine;

namespace DemolishingSystem
{
    public class DemolishingInvokerMB : MonoBehaviour, IDemolishingInvoker
    {
        [SerializeField] private ConstructionControllerMB constructionController;
        [SerializeField] private ConstructionGridManagerSO constructionGridManager;
        [SerializeField] private ACellsVisualizationMB demolitionGridVisualization;

        private IDemolishingInvoker _controller;

        private void Awake()
        {
            _controller = new DemolishingInvoker(constructionController, constructionGridManager, demolitionGridVisualization);
        }

        public BuildingStructure SelectedStructure => _controller.SelectedStructure;

        public event Action OnStructureSelected
        {
            add => _controller.OnStructureSelected += value;
            remove => _controller.OnStructureSelected -= value;
        }

        public event Action OnStructureDeselected
        {
            add => _controller.OnStructureDeselected += value;
            remove => _controller.OnStructureDeselected -= value;
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

        public void InvokeDemolishing()
        {
            _controller.InvokeDemolishing();
        }
    }
}