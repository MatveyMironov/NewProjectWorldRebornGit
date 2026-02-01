using UnityEngine;

namespace CellsVisualizationSystem
{
    public abstract class ACellsVisualizationMB : MonoBehaviour, ICellsVisualization
    {
        public abstract void CreateVisualization(Vector2Int[] cells);
        public abstract void DestroyVisualization();
    }
}