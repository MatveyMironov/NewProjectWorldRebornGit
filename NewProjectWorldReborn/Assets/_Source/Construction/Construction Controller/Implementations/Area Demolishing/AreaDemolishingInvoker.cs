using CellIndicatorSystem;
using ConstructionControllerSystem;
using ConstructionGridSystem;
using CellsVisualizationSystem;
using System;

namespace AreaDemolishingSystem
{
    public class AreaDemolishingInvoker
    {
        private readonly IConstructionController _constructionController;

        private readonly AreaDemolishingState _demolishingState;

        public AreaDemolishingInvoker(IConstructionController constructionController,
                                      IConstructionGridManager gridData,
                                      ICellIndicator cellIndicator,
                                      ICellsVisualization demolishingCellsVisualization)
        {
            _constructionController = constructionController ?? throw new ArgumentNullException(nameof(constructionController));

            _demolishingState = new(gridData, cellIndicator, demolishingCellsVisualization);
        }

        public event Action<BuildingStructure> OnBuildingDemolished
        {
            add { _demolishingState.OnBuildingDemolished += value; }
            remove { _demolishingState.OnBuildingDemolished -= value; }
        }

        public void InvokeDemolishing()
        {
            _constructionController.EnterState(_demolishingState);
        }
    }
}