using ConstructionGridSystem;
using System.Collections.Generic;
using UnityEngine;

namespace GridEditingSystem
{
    public class CellSetSaverMB : MonoBehaviour
    {
        [SerializeField] private CellSetSO cellSetSO;

        public readonly HashSet<Vector2Int> SavedCells = new();

        private void Awake()
        {
            SavedCells.UnionWith(cellSetSO.Cells);
        }

        public void SaveCellSet()
        {
            cellSetSO.SaveCellSet(SavedCells);
        }
    }
}