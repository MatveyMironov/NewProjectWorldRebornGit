using BuildingViewSystem;
using LayoutSystem;
using UnityEngine;

namespace PlacingSystem
{
    public class BuildingViewInstantiatorMB : MonoBehaviour, IBuildingViewInstantiator
    {
        [SerializeField] private Transform buildingViewsParent;
        [SerializeField] private Grid grid;

        public BuildingViewMB InstantiateBuildingView(BuildingViewMB prefab, Vector2Int cell, EOrientation orientation)
        {
            BuildingViewMB buildingView = Instantiate(prefab, buildingViewsParent);

            Vector3Int cellPosition = new(cell.x, 0, cell.y);
            Vector3 worldPosition = grid.CellToWorld(cellPosition) + grid.cellSize / 2;
            buildingView.transform.position = worldPosition;

            switch (orientation)
            {
                case EOrientation.up:
                buildingView.transform.localRotation = Quaternion.Euler(0, 0, 0);
                break;

                case EOrientation.right:
                buildingView.transform.localRotation = Quaternion.Euler(0, 90, 0);
                break;

                case EOrientation.down:
                buildingView.transform.localRotation = Quaternion.Euler(0, 180, 0);
                break;

                case EOrientation.left:
                buildingView.transform.localRotation = Quaternion.Euler(0, 270, 0);
                break;
            }

            return buildingView;
        }
    }
}
