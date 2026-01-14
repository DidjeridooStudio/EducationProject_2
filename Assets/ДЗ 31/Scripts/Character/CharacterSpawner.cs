using UnityEngine;

namespace HW_31
{
    public class CharacterSpawner
    {
        private CharacterFactory _characterFactory;

        public CharacterSpawner(CharacterFactory characterFactory)
        {
            _characterFactory = characterFactory;
        }

        public void Spawn(CharacterConfig config, Transform spawnPoint)
        {
            Character instance = _characterFactory.CreateCharacter(config, spawnPoint.position);
        }
    }
}
