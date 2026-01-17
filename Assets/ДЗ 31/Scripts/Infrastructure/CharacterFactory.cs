using Cinemachine;
using HW22_23;
using UnityEngine;

namespace HW_31
{
    public class CharacterFactory
    {
        private CharactersControllersUpdateService _characterControllersUpdateService;
        private ControllersFactory _controllersFactory;

        public CharacterFactory(CharactersControllersUpdateService characterControllersUpdateService, ControllersFactory controllersFactory)
        {
            _characterControllersUpdateService = characterControllersUpdateService;
            _controllersFactory = controllersFactory;
        }

        public Character CreateCharacter(CharacterConfig config, Vector3 spawnPosition)
        {
            Character instance = Object.Instantiate(config.Prefab, spawnPosition, Quaternion.identity);

            DirectionalMover mover = new DirectionalMover(instance.GetComponent<CharacterController>(), config.MovementSpeed);
            DirectionalRotator rotator = new DirectionalRotator(instance.transform, config.RotationSpeed);

            instance.Initialize(mover, rotator);

            CinemachineVirtualCamera followCameraPrefab = Resources.Load<CinemachineVirtualCamera>("FollowVirtualCamera");

            CinemachineVirtualCamera followCamera = Object.Instantiate(followCameraPrefab);

            followCamera.Follow = instance.CameraTarget;

            _characterControllersUpdateService.InitialaizeCharacter(instance);

            SetControllers(instance);

            return instance;
        }

        private void SetControllers(Character instance)
        {
            Controller characterController = _controllersFactory.CreateCharacteController(instance);

            characterController.Enabled();

            _characterControllersUpdateService.Add(characterController);
        }
    }
}
