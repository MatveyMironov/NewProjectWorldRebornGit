using UnityEngine;

namespace LayoutSystem
{
    public enum EOrientation
    {
        up,
        down,
        right,
        left,
    }

    public static class OrientationOperations
    {
        public static EOrientation RotateClockwise(EOrientation orientation)
        {
            switch (orientation)
            {
                case EOrientation.up:
                orientation = EOrientation.right;
                break;

                case EOrientation.right:
                orientation = EOrientation.down;
                break;

                case EOrientation.down:
                orientation = EOrientation.left;
                break;

                case EOrientation.left:
                orientation = EOrientation.up;
                break;
            }

            return orientation;
        }

        public static Quaternion GetRotation(EOrientation orientation)
        {
            return orientation switch
            {
                EOrientation.up => Quaternion.Euler(0, 0, 0),
                EOrientation.right => Quaternion.Euler(0, 90, 0),
                EOrientation.down => Quaternion.Euler(0, 180, 0),
                EOrientation.left => Quaternion.Euler(0, 270, 0),
                _ => Quaternion.identity,
            };
        }
    }
}
