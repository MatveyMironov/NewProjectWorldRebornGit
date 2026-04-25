using UnityEngine;

namespace CellsVisualizationSystem.Implementations
{
    public class IndirectInstancingCellsVizualizationMB : ACellsVisualizationMB
    {
        [SerializeField] private Grid grid;

        [Space]
        [SerializeField] private Mesh _instanceMesh;
        [SerializeField] private Material _instanceMaterial;
        [SerializeField] private string positionBufferName;

        private readonly uint[] _args = { 0, 0, 0, 0, 0 };
        private ComputeBuffer _argsBuffer;

        private ComputeBuffer _positionBuffer;

        private void Awake()
        {
            _argsBuffer = new(1, _args.Length * sizeof(uint), ComputeBufferType.IndirectArguments);
        }

        private void OnDestroy()
        {
            DestroyVisualization();

            _argsBuffer?.Release();
            _argsBuffer = null;
        }

        private void Update()
        {
            Graphics.DrawMeshInstancedIndirect(_instanceMesh, 0, _instanceMaterial, new Bounds(Vector3.zero, Vector3.one * 1000), _argsBuffer);
        }

        public override void CreateVisualization(Vector2Int[] cells)
        {
            int cellsCount = cells.Length;

            _positionBuffer?.Release();
            _positionBuffer = new ComputeBuffer(cellsCount, 16);

            Vector4[] positions = new Vector4[cellsCount];

            Vector3 offset = grid.cellSize / 2;

            for (var i = 0; i < cellsCount; i++)
            {
                Vector2Int cell = cells[i];
                Vector3Int cellPosition = new(cell.x, 0, cell.y);
                Vector3 worldPosition = grid.CellToWorld(cellPosition) + offset;
                positions[i] = worldPosition;
            }

            _positionBuffer.SetData(positions);
            _instanceMaterial.SetBuffer(positionBufferName, _positionBuffer);

            _args[0] = _instanceMesh.GetIndexCount(0);
            _args[1] = (uint)cellsCount;
            _args[2] = _instanceMesh.GetIndexStart(0);
            _args[3] = _instanceMesh.GetBaseVertex(0);
            _argsBuffer.SetData(_args);
        }

        public override void DestroyVisualization()
        {
            _positionBuffer?.Release();
            _positionBuffer = null;
        }
    }
}