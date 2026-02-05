using System.Collections.Generic;
using UnityEngine;

namespace BeaSwarm
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private List<Honeycomb> _honeycombs = new List<Honeycomb>();
        [SerializeField] private Hive _hive;

        private void Awake()
        {
            _hive.Initialize();
        }
    }
}
