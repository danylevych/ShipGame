using UnityEngine;
using UnityEngine.Audio;

public class UserSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;


    private void Start()
    {
        mixer.SetFloat("BackVolume", Mathf.Log10(PlayerPrefs.GetFloat("BackVolume", 1)) * 50);
        mixer.SetFloat("EffectVolume", Mathf.Log10(PlayerPrefs.GetFloat("EffectVolume", 1)) * 50);
        Screen.fullScreen = System.Convert.ToBoolean(PlayerPrefs.GetInt("IsFullscreen", 1));
    }
}
