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

        public HashSet<ConstructionGrid.PlacementData> GetAllPlacementsFromTo(Vector2Int firstCell, Vector2Int secondCell)
        {
            return _constructionGridManager.GetAllPlacementsFromTo(firstCell, secondCell);
        }

        public HashSet<ConstructionGrid.PlacementData> GetAllPlacementsIn(HashSet<Vector2Int> cells)
        {
            return _constructionGridManager.GetAllPlacementsIn(cells);
        }

        public HashSet<Vector2Int> GetAllCellsFromTo(Vector2Int firstCell, Vector2Int secondCell)
        {
            return _constructionGridManager.GetAllCellsFromTo(firstCell, secondCell);
        }

        public bool TryGetPlacementAt(Vector2Int cell, out ConstructionGrid.PlacementData placement)
        {
            return _constructionGridManager.TryGetPlacementAt(cell, out placement);
        }

        public bool TryPlaceStructureAt(BuildingStructure structure, Vector2Int cell)
        {
            return _constructionGridManager.TryPlaceStructureAt(structure, cell);
        }

        public bool TryRemoveStructure(BuildingStructure structure)
        {
            return ((IConstructionGridManager)_constructionGridManager).TryRemoveStructure(structure);
        }

        bool IConstructionGridManager.TryRemoveStructureAt(Vector2Int cell)
        {
            return ((IConstructionGridManager)_constructionGridManager).TryRemoveStructureAt(cell);
        }
    }
}