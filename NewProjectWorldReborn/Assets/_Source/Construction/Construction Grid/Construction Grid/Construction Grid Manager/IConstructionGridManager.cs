using System.Collections.Generic;
using UnityEngine;

namespace ConstructionGridSystem
{
    public interface IConstructionGridManager
    {
        HashSet<Vector2Int> Cells { get; }

        void RemoveStructure(BuildingStructure structure);
        bool TryPlaceStructureAt(BuildingStructure structure, Vector2Int cell);
        void RemoveStructureFrom(Vector2Int cell);
        bool CheckIfCanPlaceLayoutAt(Vector2Int cell, HashSet<Vector2Int> layoutCells);
        bool TryGetPlacementAt(Vector2Int cell, out ConstructionGrid.PlacementData placement);

        HashSet<ConstructionGrid.PlacementData> GetAllStructuresFromTo(Vector2Int firstCell, Vector2Int secondCell);
        HashSet<ConstructionGrid.PlacementData> GetAllStructuresIn(HashSet<Vector2Int> cells);
        HashSet<Vector2Int> GetAllCellsFromTo(Vector2Int firstCell, Vector2Int secondCell);
    }
}
