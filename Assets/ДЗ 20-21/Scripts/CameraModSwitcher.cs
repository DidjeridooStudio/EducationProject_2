using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

namespace HW20_21
{
    public class CameraModSwitcher : MonoBehaviour
    {
        [SerializeField] List<CinemachineVirtualCamera> _virtualCameras;

        private Queue<CinemachineVirtualCamera> _virtualCamerasQueue;

        private const KeyCode SwitchCamerasButton = KeyCode.Space;

        private void Awake()
        {
            _virtualCamerasQueue = new Queue<CinemachineVirtualCamera>(_virtualCameras);
            SwitchNextMode();
        }

        private void Update()
        {
            if (Input.GetKeyDown(SwitchCamerasButton))
                SwitchNextMode();
        }

        private void SwitchNextMode()
        {
            CinemachineVirtualCamera _nextCamera = _virtualCamerasQueue.Dequeue();

            foreach (CinemachineVirtualCamera camera in _virtualCameras)
            {
                camera.gameObject.SetActive(false);
            }

            _nextCamera.gameObject.SetActive(true);

            _virtualCamerasQueue.Enqueue(_nextCamera);
        }
    }
}
