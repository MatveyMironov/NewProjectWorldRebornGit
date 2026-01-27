using ConstructionGridSystem;
using CellsVisualizationSystem;
using UnityEngine;
using System.Linq;

namespace ConstructionSystem
{
    public class GridVisualizationConnectorMB : MonoBehaviour
    {
        [SerializeField] private ACellsVisualizationMB visualization;
        [SerializeField] private ConstructionGridManagerMB grid;

        private void Start()
        {
            visualization.CreateVisualization(grid.Cells.ToArray());
        }
    }
}