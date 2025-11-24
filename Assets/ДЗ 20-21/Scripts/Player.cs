using UnityEngine;

namespace HW20_21
{
    public class Player : MonoBehaviour
    {
        private IShooter _shooter;
        private Camera _mainCamera;
        private Porter _porter;

        private const int LeftMouseButton = 0;
        private const int RightMouseButton = 1;

        private void Awake()
        {
            _mainCamera = Camera.main;
            _porter = new Porter();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(RightMouseButton))
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
                _shooter.Shoot(ray.origin, ray.direction);
            }
            else if (Input.GetMouseButtonDown(LeftMouseButton))
            {
                Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

                _porter.PickUpObject(ray.origin, ray.direction);
            }
            else if (Input.GetMouseButton(LeftMouseButton))
            {
                _porter.CarryObject();
            }
            else if (Input.GetMouseButtonUp(LeftMouseButton))
            {
                _porter.PutObjectDown();
            }
        }

        public void SetShooter(IShooter shooter) => _shooter = shooter;
    }
}
