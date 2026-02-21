using UnityEngine;

namespace Movement
{
    public class MovementControllerMB : MonoBehaviour, IMovementController
    {
        [SerializeField] private MovementParameters movementParameters;
        [SerializeField] private MovementLimits movementLimits;

        private Vector3 _relativeDirection;

        private void Update()
        {
            Vector3 actualDirection = transform.rotation * _relativeDirection;
            Vector3 nextPodsition = transform.position + movementParameters.Speed * Time.deltaTime * actualDirection;
            transform.position = ClampPositionToMovementField(nextPodsition);
        }

        public void Move(Vector2 direction)
        {
            direction.Normalize();
            _relativeDirection = new(direction.x, 0, direction.y);
        }

        public void IncreaseSpeed()
        {
            movementParameters.IsSpeedIncreased = true;
        }

        public void DecreaseSpeed()
        {
            movementParameters.IsSpeedIncreased = false;
        }

        private Vector3 ClampPositionToMovementField(Vector3 position)
        {
            if (position.x > movementLimits.RightBorder)
                position.x = movementLimits.RightBorder;

            if (position.x < movementLimits.LeftBorder)
                position.x = movementLimits.LeftBorder;

            if (position.z > movementLimits.FrontBorder)
                position.z = movementLimits.FrontBorder;

            if (position.z < movementLimits.BackBorder)
                position.z = movementLimits.BackBorder;

            return position;
        }
    }
}