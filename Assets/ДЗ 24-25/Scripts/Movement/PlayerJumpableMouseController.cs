using HW22_23;
using UnityEngine.AI;

namespace HW24_25
{
    public class PlayerJumpableMouseController : Controller
    {
        private IJumpable _jumpable;
        private IDirectionalRotatable _rotatable;

        public PlayerJumpableMouseController(IJumpable jumpable, IDirectionalRotatable rotatable)
        {
            _jumpable = jumpable;
            _rotatable = rotatable;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            if(_jumpable.IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData))
            {
                if(_jumpable.InJumpProcess == false)
                {
                    _rotatable.SetRotateDirection(offMeshLinkData.endPos - offMeshLinkData.startPos);

                    _jumpable.Jump(offMeshLinkData);
                }
            }
        }
    }
}
