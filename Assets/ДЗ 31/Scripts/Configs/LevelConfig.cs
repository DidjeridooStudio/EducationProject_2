using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

namespace HW_31
{
    [CreateAssetMenu(menuName = "Configs/Level Config", fileName = "LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        [field: SerializeField] public VictoryConditions VictoryConditions {  get; private set; }
        [field: SerializeField] public int EnemyToKill {  get; private set; }
        [field: SerializeField] public float TimeToWin {  get; private set; }

        [field: SerializeField] public DefeatConditions DefeatConditions {  get; private set; }
        [field: SerializeField] public int EnemyNumbersToDefeat {  get; private set; }

        [field: SerializeField] public CharacterConfig CharacterConfig {  get; private set; }
        [field: SerializeField] public Vector3 CharacterSpawnPoint {  get; private set; }

        [field: SerializeField] public EvilCactusConfig EvilCactusConfig {  get; private set; }
        [field: SerializeField] public List<Vector3> EnemiesSpawnPoints {  get; private set; }
        [field: SerializeField] public int EnemiesCooldown {  get; private set; }

        [ContextMenu("UpdateStartCharacterPosition")]
        private void UpdateStartCharacterPosition()
        {
            GameObject point = GameObject.FindGameObjectWithTag("StartCharacterPosition");
            CharacterSpawnPoint = point.transform.position;
        }

        [ContextMenu("UpdateEnemiesSpawnPoints")]
        private void UpdateEnemiesSpawnPoints()
        {
            GameObject[] points = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");

            foreach (GameObject point in points)
                EnemiesSpawnPoints.Add(point.transform.position);
        }
    }
}
