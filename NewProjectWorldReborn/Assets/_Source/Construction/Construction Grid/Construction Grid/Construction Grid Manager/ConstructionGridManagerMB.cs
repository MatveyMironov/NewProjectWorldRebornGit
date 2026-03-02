using System.Collections.Generic;
using UnityEngine;

namespace ConstructionGridSystem
{
    public class ConstructionGridManagerMB : MonoBehaviour, IConstructionGridManager
    {
        [SerializeField] private CellSetSO cellSet;

        private ConstructionGridManager _constructionGridManager;

        private HashSet<Vector2Int> GridCells { get { return cellSet.Cells; } }

        protected virtual void Awake()
        {
            ConstructionGrid constructionGrid = new(GridCells);
            _constructionGridManager = new(constructionGrid);
        }

        public HashSet<Vector2Int> Cells => _constructionGridManager.Cells;

        public bool CheckIfCanPlaceLayoutAt(Vector2Int cell, HashSet<Vector2Int> buildingOccupiedCells)
        {
            return _constructionGridManager.CheckIfCanPlaceLayoutAt(cell, buildingOccupiedCells);
        }

        public HashSet<ConstructionGrid.PlacementData> GetAllStructuresFromTo(Vector2Int firstCell, Vector2Int secondCell)
        {
            return _constructionGridManager.GetAllStructuresFromTo(firstCell, secondCell);
        }

        public HashSet<ConstructionGrid.PlacementData> GetAllStructuresIn(HashSet<Vector2Int> cells)
        {
            return _constructionGridManager.GetAllStructuresIn(cells);
        }

        public HashSet<Vector2Int> GetAllCellsFromTo(Vector2Int firstCell, Vector2Int secondCell)
        {
            return _constructionGridManager.GetAllCellsFromTo(firstCell, secondCell);
        }

        public void RemoveStructure(BuildingStructure structure)
        {
            _constructionGridManager.RemoveStructure(structure);
        }

        public void RemoveStructureFrom(Vector2Int cell)
        {
            _constructionGridManager.RemoveStructureFrom(cell);
        }

        public bool TryGetPlacementAt(Vector2Int cell, out ConstructionGrid.PlacementData placement)
        {
            return _constructionGridManager.TryGetPlacementAt(cell, out placement);
        }

        public bool TryPlaceStructureAt(BuildingStructure structure, Vector2Int cell)
        {
            return _constructionGridManager.TryPlaceStructureAt(structure, cell);
        }
    }
}