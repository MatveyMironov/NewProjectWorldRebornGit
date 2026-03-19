using ConstructionControllerSystem;
using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;

namespace DemolishingSystem
{
    public class DemolitionController : IDemolitionController
    {
        private readonly IConstructionController _constructionController;

        private readonly DemolishingState _demolishingState;

        public DemolitionController(IConstructionController constructionController,
                                    IConstructionGridManager constructionGridManager,
                                    ICellsVisualization demolitionCellsVisualization)
        {
            _constructionController = constructionController ?? throw new ArgumentNullException(nameof(constructionController));

            _demolishingState = new(constructionGridManager, demolitionCellsVisualization);
        }

        public event Action OnBuildingSelected
        {
            add => _demolishingState.OnBuildingSelected += value;
            remove => _demolishingState.OnBuildingSelected -= value;
        }

        public event Action OnBuildingDeselected
        {
            add => _demolishingState.OnBuildingDeselected += value;
            remove => _demolishingState.OnBuildingDeselected -= value;
        }

        public event Action<BuildingStructure> OnBuildingDemolished
        {
            add => _demolishingState.OnBuildingDemolished += value;
            remove => _demolishingState.OnBuildingDemolished -= value;
        }

        public event Action OnStateEntered;

        public event Action OnStateExited
        {
            add => _demolishingState.OnStateExited += value;
            remove => _demolishingState.OnStateExited -= value;
        }

        public void StartDemolishing()
        {
            _constructionController.EnterState(_demolishingState);
            OnStateEntered?.Invoke();
        }
    }
}