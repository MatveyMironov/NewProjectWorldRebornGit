using UnityEngine;

namespace Rotation
{
    public class RotationControllerMB : MonoBehaviour, IRotationController
    {
        [SerializeField] private Transform _rotationAxisX;
        [SerializeField] private Transform _rotationAxisY;

        [Space]
        [SerializeField] private RotationInputParameters rotationInputParameters;
        [SerializeField] private RotationLimits rotationLimits;

        public void Rotate(Vector2 rotationAmount)
        {
            Vector2 rotation = new(rotationAmount.y * rotationInputParameters.XRotationFactor, rotationAmount.x * rotationInputParameters.YRotationFactor);

            if (_rotationAxisX.rotation.eulerAngles.x + rotation.x > rotationLimits.MaxXAngle)
            {
                rotation.x = rotationLimits.MaxXAngle - _rotationAxisX.rotation.eulerAngles.x;
            }
            else if (_rotationAxisX.rotation.eulerAngles.x + rotation.x < rotationLimits.MinXAngle)
            {
                rotation.x = rotationLimits.MinXAngle - _rotationAxisX.rotation.eulerAngles.x;
            }

            _rotationAxisX.Rotate(rotation.x, 0, 0);
            _rotationAxisY.Rotate(0, rotation.y, 0);
        }
    }
}