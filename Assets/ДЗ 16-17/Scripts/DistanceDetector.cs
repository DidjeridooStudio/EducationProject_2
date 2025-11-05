using UnityEngine;

namespace HW16_17
{
    public static class DistanceDetector
    {
        public static Vector3 DirectionToTarget(Vector3 targetPosition, Vector3 objectPosition) => targetPosition - objectPosition;

        public static bool IsTargetInSpecifiedZone(Vector3 directionToTarget, float specifiedDistance)
        {
            if (directionToTarget.magnitude <= specifiedDistance)
                return true;

            return false;
        }
    }
}
