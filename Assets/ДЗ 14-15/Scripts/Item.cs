using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;
    [SerializeField] protected float _destroyTimeAfterUse;
    [SerializeField] protected ParticleSystem _explodeEffect;

    private Vector3 _defaultPosition;
    private float _time;

    private void Awake()
    {
        _defaultPosition = transform.position;
    }

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        _time += Time.deltaTime;

        transform.Rotate(Vector3.up, Time.deltaTime * _rotateSpeed);
    }

    public virtual void Use(GameObject affectedGameObject)
    {
        _explodeEffect.Play();
        Destroy(gameObject, _destroyTimeAfterUse);
    }
}
