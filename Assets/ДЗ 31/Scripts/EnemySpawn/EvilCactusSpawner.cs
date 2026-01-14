using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace HW_31
{
    public class EvilCactusSpawner
    {
        private WaitForSeconds _waitCooldown;
        private EnemiesFactory _enemiesFactory;
        private MonoBehaviour _coroutineRunner;
        private EvilCactusConfig _config;
        private List<Vector3> _spawnPoints;

        private bool _isGameInProcess;
        private Coroutine _coroutine;


        public EvilCactusSpawner(
            EnemiesFactory characterFactory,
            EvilCactusConfig config,
            List<Vector3> spawnPoints,
            MonoBehaviour coroutineRunner)
        {
            _enemiesFactory = characterFactory;
            _config = config;
            _spawnPoints = spawnPoints;
            _coroutineRunner = coroutineRunner;

            _isGameInProcess = true;
        }

        public void StopSpawn()
        {
            _isGameInProcess = false;

            if (_coroutine != null)
                _coroutineRunner.StopCoroutine(_coroutine);
        }

        public void SpawnEntity(int cooldown)
        {
            _waitCooldown = new WaitForSeconds(cooldown);
            _coroutine = _coroutineRunner.StartCoroutine(SpawnProcess());
        }

        private IEnumerator SpawnProcess()
        {
            while(_isGameInProcess)
            {
                yield return _waitCooldown;

                int randomIndex = Random.Range(0, _spawnPoints.Count);
                EvilCactus entity = _enemiesFactory.CreateEvilCactus(_config, _spawnPoints[randomIndex]);   
            }
        }
    }
}
