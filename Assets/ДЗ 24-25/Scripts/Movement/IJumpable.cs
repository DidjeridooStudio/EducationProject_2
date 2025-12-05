using UnityEngine.AI;

namespace HW24_25
{
    public interface IJumpable
    {
        bool InJumpProcess { get; }

        bool IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData);

        void Jump(OffMeshLinkData offMeshLinkData);
    }
}
