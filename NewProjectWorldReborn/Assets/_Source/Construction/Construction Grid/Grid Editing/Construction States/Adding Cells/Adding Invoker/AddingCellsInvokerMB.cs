using CellIndicatorSystem;
using ConstructionControllerSystem;
using CellsVisualizationSystem;
using UnityEngine;

namespace GridEditingSystem
{
    public class AddingCellsInvokerMB : MonoBehaviour, IAddingCellsInvoker
    {
        [SerializeField] private ConstructionControllerMB constructionController;
        [SerializeField] private CellSetSaverMB cellSet;
        [SerializeField] private CellIndicatorMB cellIndicator;
        [SerializeField] private ACellsVisualizationMB validCellsVisualization;
        [SerializeField] private ACellsVisualizationMB addedCellsVisualization;

        private IAddingCellsInvoker _addingCellsInvoker;

        private void Awake()
        {
            _addingCellsInvoker = new AddingCellsInvoker(constructionController,
                                                         cellSet.SavedCells,
                                                         cellIndicator,
                                                         validCellsVisualization,
                                                         addedCellsVisualization);
        }

        public void InvokeAddingCells()
        {
            _addingCellsInvoker.InvokeAddingCells();
        }
    }
}