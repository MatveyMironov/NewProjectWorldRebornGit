using ConstructionGridSystem;
using CellsVisualizationSystem;
using UnityEngine;
using System.Linq;

namespace ConstructionSystem
{
    public class GridVisualizationConnectorMB : MonoBehaviour
    {
        [SerializeField] private ACellsVisualizationMB visualization;
        [SerializeField] private ConstructionGridManagerSO grid;

        private void Start()
        {
            visualization.CreateVisualization(grid.Cells.ToArray());
        }
    }
}