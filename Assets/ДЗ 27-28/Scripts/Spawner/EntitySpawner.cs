using UnityEngine;

namespace HW27_28
{
    public class EntitySpawner : MonoBehaviour
    {
        [SerializeField] private Entity _entityPrefabs;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private DestructionService _destructionService;

        private const KeyCode CreateLogicalDeathConditionEntityKey = KeyCode.Alpha1;
        private const KeyCode CreateMaxCountDeathConditionEntityKey = KeyCode.Alpha2;
        private const KeyCode CreateLifeTimeDeathConditionEntityKey = KeyCode.Alpha3;
        private const int EntityMaxCount = 10;
        private const int EntityMaxLifeTime = 5;

        private void Update()
        {
            if (Input.GetKeyDown(CreateLogicalDeathConditionEntityKey))
                ActivateSpawnPoints((entity) => entity.IsDead, Color.red);

            if (Input.GetKeyDown(CreateMaxCountDeathConditionEntityKey))
                ActivateSpawnPoints((entity) => _destructionService.EntitiesCount > EntityMaxCount, Color.green);

            if (Input.GetKeyDown(CreateLifeTimeDeathConditionEntityKey))
                ActivateSpawnPoints((entity) => entity.LifeTime >= EntityMaxLifeTime, Color.black);
        }

        private void ActivateSpawnPoints(DeathCondition deathCondition, Color color)
        {
            Entity sphere = Instantiate(_entityPrefabs, _spawnPoint.position, Quaternion.identity);
            sphere.GetComponent<MeshRenderer>().material.color = color;

            _destructionService.AddEntity(sphere, deathCondition);
        }
    }
}
