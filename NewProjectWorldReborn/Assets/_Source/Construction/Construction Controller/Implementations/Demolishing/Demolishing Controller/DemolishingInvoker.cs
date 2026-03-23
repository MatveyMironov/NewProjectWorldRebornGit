using ConstructionControllerSystem;
using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;

namespace DemolishingSystem
{
    public class DemolishingInvoker : IDemolishingInvoker
    {
        private readonly IConstructionController _constructionController;

        private readonly DemolishingState _demolishingState;

        public DemolishingInvoker(IConstructionController constructionController,
                                    IConstructionGridManager constructionGridManager,
                                    ICellsVisualization demolitionCellsVisualization)
        {
            _constructionController = constructionController ?? throw new ArgumentNullException(nameof(constructionController));

            _demolishingState = new(constructionGridManager, demolitionCellsVisualization);
        }

        public BuildingStructure SelectedStructure => _demolishingState.SelectedStructure;

        public event Action OnStructureSelected
        {
            add => _demolishingState.OnStructureSelected += value;
            remove => _demolishingState.OnStructureSelected -= value;
        }

        public event Action OnStructureDeselected
        {
            add => _demolishingState.OnStructureDeselected += value;
            remove => _demolishingState.OnStructureDeselected -= value;
        }

        public event Action<BuildingStructure> OnBuildingDemolished
        {
            add => _demolishingState.OnStructureDemolished += value;
            remove => _demolishingState.OnStructureDemolished -= value;
        }

        public event Action OnStateEntered
        {
            add => _demolishingState.OnStateEntered += value;
            remove => _demolishingState.OnStateEntered -= value;
        }

        public event Action OnStateExited
        {
            add => _demolishingState.OnStateExited += value;
            remove => _demolishingState.OnStateExited -= value;
        }

        public void InvokeDemolishing()
        {
            _constructionController.EnterState(_demolishingState);
        }
    }
}