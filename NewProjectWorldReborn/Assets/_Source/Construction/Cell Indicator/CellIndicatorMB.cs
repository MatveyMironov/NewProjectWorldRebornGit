using UnityEngine;

namespace CellIndicatorSystem
{
    public class CellIndicatorMB : MonoBehaviour, ICellIndicator
    {
        [SerializeField] private Grid grid;

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void MoveToCell(Vector2Int cell)
        {
            Vector3Int cellPosition = new(cell.x, 0, cell.y);
            Vector3 worldPosition = grid.CellToWorld(cellPosition);

            transform.position = worldPosition;
        }
    }
}