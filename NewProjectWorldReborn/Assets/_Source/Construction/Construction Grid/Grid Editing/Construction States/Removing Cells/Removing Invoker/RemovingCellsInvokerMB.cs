using CellIndicatorSystem;
using ConstructionControllerSystem;
using CellsVisualizationSystem;
using UnityEngine;

namespace GridEditingSystem
{
    public class RemovingCellsInvokerMB : MonoBehaviour, IRemovingCellsInvoker
    {
        [SerializeField] private ConstructionControllerMB constructionController;
        [SerializeField] private CellSetSaverMB cellSet;
        [SerializeField] private CellIndicatorMB cellIndicator;
        [SerializeField] private ACellsVisualizationMB validCellsVisualization;
        [SerializeField] private ACellsVisualizationMB removedCellsVisualization;

        private IRemovingCellsInvoker _removingCellsInvoker;

        private void Awake()
        {
            _removingCellsInvoker = new RemovingCellsInvoker(constructionController,
                                                             cellSet.SavedCells,
                                                             cellIndicator,
                                                             validCellsVisualization,
                                                             removedCellsVisualization);
        }

        public void InvokeRemovingCellsState()
        {
            _removingCellsInvoker.InvokeRemovingCellsState();
        }
    }
}