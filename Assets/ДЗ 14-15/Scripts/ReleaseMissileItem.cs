using UnityEngine;

public class ReleaseMissileItem : Item
{
    [SerializeField] private GameObject _missilePrefab;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _force;
    [SerializeField] private float _missleDestroyTime;

    public override void Use(GameObject affectedGameObject)
    {
        Shoot(affectedGameObject);
        base.Use(affectedGameObject);
    }

    private void Shoot(GameObject affectedGameObject)
    {
        GameObject missile = InstantiateMissile(affectedGameObject);

        if (missile.TryGetComponent<Rigidbody>(out Rigidbody missleRigidbody))
        {
            missleRigidbody.AddForce(affectedGameObject.transform.forward * _force, ForceMode.Impulse);
        }

        Destroy(missile, _missleDestroyTime);
    }

    private GameObject InstantiateMissile(GameObject affectedGameObject)
    {
        GameObject missile = Instantiate(_missilePrefab);
        missile.transform.position = affectedGameObject.transform.position + _offset;

        Vector3 direction = new Vector3(missile.transform.eulerAngles.x, affectedGameObject.transform.eulerAngles.y, missile.transform.eulerAngles.z);
        missile.transform.rotation = Quaternion.Euler(direction);

        return missile;
    }
}
