using UnityEngine;

namespace HW16_17
{
    public class SphereSpawnPoint : MonoBehaviour
    {
        [SerializeField] private IdleBehaviors _idleBehavior;
        [SerializeField] private ReactionBehaviors _reactionBehavior;

        public IdleBehaviors IdleBehavior => _idleBehavior;
        public ReactionBehaviors ReactionBehavior => _reactionBehavior;

        public Vector3 Position => transform.position;
    }
}
