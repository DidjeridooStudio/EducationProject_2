using UnityEngine;

namespace HW20_21
{
    public class RayShooter : IShooter
    {
        private IShootEffect _shootEffect;

        public RayShooter(IShootEffect shootEffect)
        {
            _shootEffect = shootEffect;
        }

        #region Interface

        public void Shoot(Vector3 origin, Vector3 direction)
        {
            Ray ray = new Ray(origin, direction);

            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                _shootEffect.Execute(hitInfo.point);
            }
        }

        #endregion
    }
}
