using UnityEngine;

namespace HW22_23
{
    public interface IDirectionalMovable : ITransformPosition
    {
        Vector3 CurrentVelocity { get; }

        void SetMoveDirection(Vector3 direction);
    }
}
