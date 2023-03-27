using UnityEngine;
using UnityEngine.Audio;

public class UserSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;


    private void Start()
    {
        mixer.SetFloat("BackVolume", (-80 + PlayerPrefs.GetFloat("BackVolume", 1) * 100));
        mixer.SetFloat("EffectVolume", (-80 + PlayerPrefs.GetFloat("EffectVolume", 1) * 100));
        Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("IsFullscreen", 1));
    }
}
