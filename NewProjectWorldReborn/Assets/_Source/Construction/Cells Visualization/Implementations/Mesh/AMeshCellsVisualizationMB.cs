using System.Collections.Generic;
using UnityEngine;

namespace CellsVisualizationSystem.Implementations
{
    public abstract class AMeshCellsVisualizationMB : ACellsVisualizationMB
    {
        [SerializeField] private Grid grid;
        [SerializeField] private Mesh cellMesh;
        [SerializeField] private Material cellMaterial;

        [Header("Sorta Culling")]
        [SerializeField] private Transform mainCamera;
        [Tooltip("Max distance from camera to displayed cells in cell length")]
        [SerializeField] private int cullingDistance;

        private RenderParams _renderParams;

        public struct InstanceData
        {
            public Vector3 worldPosition;
            public Matrix4x4 objectToWorld;
            public uint renderingLayerMask;
            public float distanceToCamera;
        }

        private readonly Dictionary<Vector2Int, InstanceData> _rememberedInstances = new();

        // For performance
        private Vector3 _lastCameraPosition;
        private Vector3Int _lastCameraGridPosition;

        protected readonly Dictionary<Vector2Int, InstanceData> CulledInstances = new();

        protected abstract InstanceData[] RenderedInstances { get; }

        protected virtual void Awake()
        {
            cellMaterial.enableInstancing = true;

            _renderParams = new(cellMaterial)
            {
                shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off,
                receiveShadows = false
            };
        }

        protected virtual void Update()
        {
            UpdateRenderedInstancesIfNecessary();

            if (RenderedInstances.Length > 0)
            {
                Graphics.RenderMeshInstanced(_renderParams, cellMesh, 0, RenderedInstances);
            }

            void UpdateRenderedInstancesIfNecessary()
            {
                Vector3 cameraPosition = mainCamera.position;
                if (cameraPosition == _lastCameraPosition) return;
                _lastCameraPosition = cameraPosition;

                Vector3Int cameraGridPosition = grid.WorldToCell(_lastCameraPosition);
                if (cameraGridPosition == _lastCameraGridPosition) return;
                _lastCameraGridPosition = cameraGridPosition;

                CreateCulledInstances();
            }
        }

        public override void CreateVisualization(Vector2Int[] cells)
        {
            DestroyVisualization();

            foreach (Vector2Int cell in cells)
            {
                if (_rememberedInstances.TryAdd(cell, default))
                {
                    Vector3Int cellPosition = new(cell.x, 0, cell.y);
                    Vector3 worldPosition = grid.CellToWorld(cellPosition) + (grid.cellSize / 2);

                    InstanceData instanceData = new()
                    {
                        worldPosition = worldPosition,
                        objectToWorld = Matrix4x4.TRS(worldPosition, Quaternion.identity, Vector3.one * 0.1f),
                        renderingLayerMask = 1u,
                    };

                    _rememberedInstances[cell] = instanceData;
                }
            }

            CreateCulledInstances();
        }

        public override void DestroyVisualization()
        {
            _rememberedInstances.Clear();
            CulledInstances.Clear();
        }

        private void CreateCulledInstances()
        {
            Vector2Int cameraCell = new(_lastCameraGridPosition.x, _lastCameraGridPosition.z);

            CulledInstances.Clear();

            for (int x = -cullingDistance; x <= cullingDistance; x++)
            {
                for (int y = -cullingDistance; y <= cullingDistance; y++)
                {
                    Vector2Int cell = new(cameraCell.x + x, cameraCell.y + y);

                    if (_rememberedInstances.TryGetValue(cell, out var instance))
                    {
                        CulledInstances.TryAdd(cell, instance);
                    }
                }
            }
        }
    }
}
