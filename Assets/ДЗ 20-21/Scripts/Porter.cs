using UnityEngine;

namespace HW20_21
{
    public class Porter
    {
        private GameObject _selectedObject;
        private Vector3 _pointScreen;
        private LayerMask _layerMask;
        private Camera _mainCamera;

        public Porter(LayerMask layerMask)
        {
            _layerMask = layerMask;
            _mainCamera = Camera.main;
        }

        public void PickUpObject(Vector3 origin, Vector3 direction)
        {
            Ray ray = new Ray(origin, direction);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, _layerMask.value))
            {
                _selectedObject = hitInfo.collider.gameObject;
                _pointScreen = _mainCamera.WorldToScreenPoint(_selectedObject.transform.position);
            }
        }

        public void CarryObject()
        {
            if (_selectedObject != null)
            {
                Vector3 currentScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _pointScreen.z);
                Vector3 currentWorldPosition = _mainCamera.ScreenToWorldPoint(currentScreenPosition);
                _selectedObject.transform.position = new Vector3(currentWorldPosition.x, Mathf.Clamp(currentWorldPosition.y, 0, 10), currentWorldPosition.z);
                _selectedObject.transform.rotation = Quaternion.identity;
            }
        }

        public void PutObjectDown()
        {
            _selectedObject = null;
        }
    }
}
