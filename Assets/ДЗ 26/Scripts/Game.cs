using UnityEngine;

namespace HW26
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private GameObject _defeatPopup;

        private const int OutsideLevelZonePosition = -20;

        private void Update()
        {
            if (_character.IsDead || _character.transform.position.y < OutsideLevelZonePosition)
                LoseGame();
        }

        private void LoseGame()
        {
            Time.timeScale = 0;
            _character.gameObject.SetActive(false);
            _defeatPopup.SetActive(true);
        }

        public void RestartGame()
        {
            _character.transform.position = Vector3.zero;
            Time.timeScale = 1;
            _character.gameObject.SetActive(true);
            _character.IsDead = false;
            _defeatPopup.SetActive(false);
        }
    }
}
