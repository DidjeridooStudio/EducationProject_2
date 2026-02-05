using UnityEngine;

namespace BeaSwarm
{
    public interface IDirectionalRotatable : ITransformPosition
    {
        Quaternion CurrentRotation { get; }

        void SetRotateDirection(Vector3 direction);
    }
}
