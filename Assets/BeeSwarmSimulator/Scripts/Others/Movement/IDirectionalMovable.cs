using UnityEngine;

namespace BeaSwarm
{
    public interface IDirectionalMovable : ITransformPosition
    {
        Vector3 CurrentVelocity { get; }

        void SetMoveDirection(Vector3 direction);
    }
}
