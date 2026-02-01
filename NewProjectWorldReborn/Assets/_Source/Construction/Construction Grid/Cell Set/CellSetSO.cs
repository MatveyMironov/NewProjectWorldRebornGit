using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ConstructionGridSystem
{
    [CreateAssetMenu(fileName = "NewCellSetSO", menuName = "Construction/Cell Set")]
    public class CellSetSO : ScriptableObject
    {
        [SerializeField] private Vector2Int[] cells = new Vector2Int[0];

        public HashSet<Vector2Int> Cells { get => cells.ToHashSet(); }

        public void SaveCellSet(HashSet<Vector2Int> savedCells)
        {
            cells = savedCells.ToArray();
        }
    }
}