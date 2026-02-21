using UnityEngine;

namespace Movement
{
    public interface IMovementController
    {
        public void Move(Vector2 direction);
        public void IncreaseSpeed();
        public void DecreaseSpeed();
    }
}
