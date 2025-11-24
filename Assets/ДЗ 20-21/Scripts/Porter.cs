using UnityEngine;

namespace HW20_21
{
    public class Porter
    {
        private IDraggable _selectedObject;
        private Vector3 _pointScreen;
        private Camera _mainCamera;

        public Porter()
        {
            _mainCamera = Camera.main;
        }

        public void PickUpObject(Vector3 origin, Vector3 direction)
        {
            Ray ray = new Ray(origin, direction);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                _selectedObject = hitInfo.collider.gameObject.GetComponent<IDraggable>();

                if (_selectedObject == null)
                    return;

                _pointScreen = _mainCamera.WorldToScreenPoint(_selectedObject.Position);
                _selectedObject.OnGrab();
            }
        }

        public void CarryObject()
        {
            if (_selectedObject != null)
            {
                Vector3 currentScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _pointScreen.z);
                Vector3 currentWorldPosition = _mainCamera.ScreenToWorldPoint(currentScreenPosition);
                _selectedObject.Drag(new Vector3(currentWorldPosition.x, Mathf.Clamp(currentWorldPosition.y, 0, 10), currentWorldPosition.z));
            }
        }

        public void PutObjectDown()
        {
            if (_selectedObject == null)
                return;

            _selectedObject.OnRelease();
            _selectedObject = null;
        }
    }
}
