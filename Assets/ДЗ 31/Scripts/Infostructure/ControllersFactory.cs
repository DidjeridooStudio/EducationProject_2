using HW22_23;

namespace HW_31
{
    public class ControllersFactory
    {
        public PlayerDirectionalMovableController CreatePlayerDirectionalMovableController(IDirectionalMovable movable)
        {
            return new PlayerDirectionalMovableController(movable);
        }

        public AlongMovableVelocityRotatableController CreateAlongMovableVelocityRotatableController(
            IDirectionalRotatable rotatable, IDirectionalMovable movable)
        {
            return new AlongMovableVelocityRotatableController(rotatable, movable);
        }

        public CompositeController CreateCharacteController(Character character)
        {
            return new CompositeController(
                CreatePlayerDirectionalMovableController(character),
                CreateAlongMovableVelocityRotatableController(character, character));
        }
    }
}
