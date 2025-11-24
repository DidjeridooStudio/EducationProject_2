using UnityEngine;

public interface IDraggable
{
    Vector3 Position { get; }

    void OnGrab();

    void Drag(Vector3 position);

    void OnRelease();
}
