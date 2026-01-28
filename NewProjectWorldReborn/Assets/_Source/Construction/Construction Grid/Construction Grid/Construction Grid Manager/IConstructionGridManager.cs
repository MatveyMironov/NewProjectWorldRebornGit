using System.Collections.Generic;
using UnityEngine;

namespace ConstructionGridSystem
{
    public interface IConstructionGridManager
    {
        public HashSet<Vector2Int> Cells { get; }

        public void RemoveBuilding(BuildingStructure building);
        public bool TryPlaceBuilding(BuildingStructure building, Vector2Int cell);
        public void RemoveBuilding(Vector2Int cell);
        public bool CheckIfCanPlaceBuilding(Vector2Int cell, HashSet<Vector2Int> layoutCells);
        public bool TryGetBuilding(Vector2Int cell, out BuildingStructure building);

        #region Selection
        public HashSet<BuildingStructure> GetAllBuildingsFromTo(Vector2Int firstCell, Vector2Int secondCell);
        public HashSet<BuildingStructure> GetAllBuildingsIn(HashSet<Vector2Int> cells);
        public HashSet<Vector2Int> GetAllCellsFromTo(Vector2Int firstCell, Vector2Int secondCell);
        #endregion
    }
}
