using System.Linq;

namespace CellsVisualizationSystem.Implementations
{
    public class DefaultMeshCellsVisualizationMB : AMeshCellsVisualizationMB
    {
        protected override InstanceData[] RenderedInstances { get => CulledInstances.Values.ToArray(); }
    }
}
