using HW22_23;
using System.Collections.Generic;
using UnityEngine;

namespace HW_31
{
    public class CharactersControllersUpdateService
    {
        private Character _instance;
        private List<Controller> _controllers = new List<Controller>();

        public void InitialaizeCharacter(Character instance)
        {
            _instance = instance;
        }

        public void Add(Controller controller)
        {
            _controllers.Add(controller);
        }

        public void Update(float deltaTime)
        {
            foreach (Controller controller in _controllers)
                controller.Update(deltaTime);

            DisabledControllerOnDeathCharacter();
        }

        private void DisabledControllerOnDeathCharacter()
        {
            if (_instance.IsDead)
            {
                _instance.SetMoveDirection(Vector3.zero);

                foreach (Controller controller in _controllers)
                    controller.Disabled();
            }
        }
    }
}
