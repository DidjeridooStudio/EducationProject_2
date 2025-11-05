using System;
using System.Collections.Generic;
using UnityEngine;

namespace HW16_17
{
    public class SphereSpawner : MonoBehaviour
    {
        [SerializeField] private Sphere _spherePrefabs;
        [SerializeField] private Transform _characterTransform;
        [SerializeField] private List<Transform> _targetsTransform;
        [SerializeField] private List<SphereSpawnPoint> _sphereSpawnPoints;

        private void Start()
        {
            ActivateSpawnPoints();
        }

        private void ActivateSpawnPoints()
        {
            foreach (SphereSpawnPoint spawnPoint in _sphereSpawnPoints)
            {
                Sphere sphere = Instantiate(_spherePrefabs, spawnPoint.Position, Quaternion.identity);

                IIdleBehavior idleBehavior = ChooseIdleBehavior(spawnPoint.IdleBehavior, sphere);

                IReactionBehavior reactionBehavior = ChooseReactionBehavior(spawnPoint.ReactionBehavior, sphere);

                sphere.Initialize(idleBehavior, reactionBehavior, _characterTransform);
            }
        }

        private IIdleBehavior ChooseIdleBehavior(IdleBehaviors behavior, Sphere sphere)
        {
            IIdleBehavior idleBehavior = new PatrolIdleBehavior(sphere.transform, _targetsTransform);

            switch (behavior)
            {
                case IdleBehaviors.Patrol:
                    idleBehavior = new PatrolIdleBehavior(sphere.transform, _targetsTransform);
                    break;
                case IdleBehaviors.RandomWalk:
                    idleBehavior = new RandomWalkIdleBehavior(sphere.transform);
                    break;
                case IdleBehaviors.StandsStill:
                    idleBehavior = new StandsStillIdleBehavior(sphere.transform);
                    break;
                default:
                    Debug.LogError($"Поведение покоя {behavior} не поддерживается");
                    break;
            }

            return idleBehavior;
        }
        private IReactionBehavior ChooseReactionBehavior(ReactionBehaviors behavior, Sphere sphere)
        {
            IReactionBehavior reactionBehavior = new AvoidantReactionBehavior(sphere.transform, _characterTransform);

            switch (behavior)
            {
                case ReactionBehaviors.Avoidant:
                    reactionBehavior = new AvoidantReactionBehavior(sphere.transform, _characterTransform);
                    break;
                case ReactionBehaviors.Agressive:
                    reactionBehavior = new AgressiveReactionBehavior(sphere.transform, _characterTransform);
                    break;
                case ReactionBehaviors.Fearful:
                    ExplodeEffect[] sphereEffects = sphere.GetComponentsInChildren<ExplodeEffect>();
                    ParticleSystem explodeEffect = sphereEffects[0].gameObject.GetComponent<ParticleSystem>();
                    reactionBehavior = new FearfulReactionBehavior(sphere.transform, explodeEffect);
                    break;
                default:
                    Debug.LogError($"Поведение реакции {behavior} не поддерживается");
                    break;
            }

            return reactionBehavior;
        }
    }
}
