using UnityEngine;

namespace CellIndicatorSystem
{
    public interface ICellIndicator
    {
        public void Show();
        public void Hide();
        public void MoveToCell(Vector2Int cell);
    }
}