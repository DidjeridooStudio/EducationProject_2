using UnityEngine;

namespace HW22_23
{
    public interface IDirectionalRotatable : ITransformPosition
    {
        Quaternion CurrentRotation { get; }

        void SetRotateDirection(Vector3 direction);
    }
}
