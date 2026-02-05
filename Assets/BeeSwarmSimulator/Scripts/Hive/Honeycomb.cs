using UnityEngine;

public class Honeycomb : MonoBehaviour
{
    [SerializeField] private BeeConfig _beeConfig;

    private BeeSpawner _beeSpawner;

    public void Initialize(BeeSpawner beeSpawner)
    {
        _beeSpawner = beeSpawner;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_beeConfig != null)
                _beeSpawner.Spawn(_beeConfig, transform);
        }
    }
}
