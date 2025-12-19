using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HW27_28
{
    public class DestructionService : MonoBehaviour
    {
        [SerializeField] private EntitySpawner _entitySpawner;
        [SerializeField] private TMP_Text _enemiesTMP_Text;

        private List<Entity> _entities;
        private Dictionary<Entity, DeathCondition> _entitiesDeathCondition;
        public int EntitiesCount => _entities.Count;

        private void Start()
        {
            _entities = new List<Entity>();
            _entitiesDeathCondition = new Dictionary<Entity, DeathCondition>();
        }

        private void Update()
        {
            ShowEntitiesCount();
            CheckDeathCondition();
        }

        public void AddEntity(Entity entity, DeathCondition deathCondition)
        {
            _entities.Add(entity);
            _entitiesDeathCondition.Add(entity, deathCondition);
        }
        
        private void ShowEntitiesCount()
        {
            _enemiesTMP_Text.text = $"Spheres: {EntitiesCount.ToString()}";
        }

        private void CheckDeathCondition()
        {
            foreach (Entity entity in _entities)
            {
                if (_entitiesDeathCondition[entity].Invoke(entity))
                {
                    Destroy(entity.gameObject);
                    _entities.Remove(entity);
                    _entitiesDeathCondition.Remove(entity);
                    break;
                }
            }
        }
    }
}
