using UnityEngine;

namespace HW20_21
{
    public class ShooterSetter : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private float _explosionRadius;
        [SerializeField] private float _explosionForce;
        [SerializeField] private ParticleSystem _explodeEffect;
        [SerializeField] private Shooters _shooterEnum;
        [SerializeField] private ShootEffects _shootEffectEnum;

        private void Awake()
        {
            IShootEffect shootEffect = CreateShootEffect(_shootEffectEnum);
            IShooter shooter = CreateShooter(_shooterEnum, shootEffect);

            _player.SetShooter(shooter);
        }

        private IShootEffect CreateShootEffect(ShootEffects shootEffectEnum)
        {
            IShootEffect shootEffect = new ExplosionEffect(_explosionRadius, _explosionForce, _explodeEffect);

            switch (shootEffectEnum)
            {
                case ShootEffects.ExplosionEffect:
                    shootEffect = new ExplosionEffect(_explosionRadius, _explosionForce, _explodeEffect);
                    break;
                default:
                    Debug.LogError($"Shoot effect {shootEffectEnum} is not supported");
                    break;
            }

            return shootEffect;
        }

        private IShooter CreateShooter(Shooters shooterEnum, IShootEffect shootEffect)
        {
            IShooter shooter = new RayShooter(shootEffect);

            switch (shooterEnum)
            {
                case Shooters.RayShooter:
                    new RayShooter(shootEffect);
                    break;
                default:
                    Debug.LogError($"Shooter {shooterEnum} is not supported");
                    break;
            }

            return shooter;
        }
    }
}
