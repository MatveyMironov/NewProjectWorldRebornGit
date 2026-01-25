using UnityEngine;

namespace ConstructionControllerSystem
{
    public class ConstructionControllerMB : MonoBehaviour, IConstructionController
    {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private LayerMask layers;
        [SerializeField] private Grid grid;

        private IConstructionController _controller;

        private void Awake()
        {
            _controller = new ConstructionController(mainCamera, layers, grid);
        }

        public void AbortAction()
        {
            _controller.AbortAction();
        }

        public void FinishAction()
        {
            _controller.FinishAction();
        }

        public void SetState(IConstructionState state)
        {
            _controller.SetState(state);
        }

        public void StartAction()
        {
            _controller.StartAction();
        }

        public void UpdateMousePosition(Vector2 mousePosition)
        {
            _controller.UpdateMousePosition(mousePosition);
        }
    }
}