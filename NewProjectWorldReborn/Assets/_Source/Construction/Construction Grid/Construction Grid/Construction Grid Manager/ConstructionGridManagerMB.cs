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

        public bool CheckIfCanPlaceBuilding(Vector2Int originCell, HashSet<Vector2Int> buildingOccupiedCells)
        {
            return _constructionGridManager.CheckIfCanPlaceBuilding(originCell, buildingOccupiedCells);
        }

        public HashSet<ConstructedBuilding> GetAllBuildingsFromTo(Vector2Int firstCell, Vector2Int secondCell)
        {
            return _constructionGridManager.GetAllBuildingsFromTo(firstCell, secondCell);
        }

        public HashSet<ConstructedBuilding> GetAllBuildingsIn(HashSet<Vector2Int> cells)
        {
            return _constructionGridManager.GetAllBuildingsIn(cells);
        }

        public HashSet<Vector2Int> GetAllCellsFromTo(Vector2Int firstCell, Vector2Int secondCell)
        {
            return _constructionGridManager.GetAllCellsFromTo(firstCell, secondCell);
        }

        public void RemoveBuilding(ConstructedBuilding constructedBuildingData)
        {
            _constructionGridManager.RemoveBuilding(constructedBuildingData);
        }

        public void RemoveBuilding(Vector2Int cell)
        {
            _constructionGridManager.RemoveBuilding(cell);
        }

        public bool TryGetBuilding(Vector2Int cell, out ConstructedBuilding constructedBuildingData)
        {
            return _constructionGridManager.TryGetBuilding(cell, out constructedBuildingData);
        }

        public bool TryPlaceBuilding(ConstructedBuilding constructedBuildingData, Vector2Int originCell)
        {
            return _constructionGridManager.TryPlaceBuilding(constructedBuildingData, originCell);
        }
    }
}