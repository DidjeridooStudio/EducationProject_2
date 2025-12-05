using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace HW24_25
{
    public class AudioManager : MonoBehaviour
    {
        private const float OffVolumeValue = -80;
        private const float OnVolumeValue = 0;

        private const string MusicKey = "MusicVolume";
        private const string SoundsKey = "SoundsVolume";

        [SerializeField] AudioMixer _audioMixer;

        public void SwitchMusicVolume(TMP_Text TMP_Text)
        {
            if (IsVolumeOn(MusicKey))
            {
                _audioMixer.SetFloat(MusicKey, OffVolumeValue);
                TMP_Text.text = "Music Off";
            }
            else
            {
                _audioMixer.SetFloat(MusicKey, OnVolumeValue);
                TMP_Text.text = "Music On";
            }
        }

        public void SwitchSoundsVolume(TMP_Text TMP_Text)
        {
            if (IsVolumeOn(SoundsKey))
            {
                _audioMixer.SetFloat(SoundsKey, OffVolumeValue);
                TMP_Text.text = "Sounds Off";
            }
            else
            {
                _audioMixer.SetFloat(SoundsKey, OnVolumeValue);
                TMP_Text.text = "Sounds On";
            }
        }

        private bool IsVolumeOn(string key) => _audioMixer.GetFloat(key, out float volume) && volume == OnVolumeValue;
    }
}
