
namespace HW_31
{
    public class CharacterIsDeadCondition : ICondition
    {
        private Character _character;

        public CharacterIsDeadCondition(Character character)
        {
            _character = character;
        }

        public bool Completed() => _character.IsDead;
    }
}
