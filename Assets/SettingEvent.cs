using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


public class SettingEvent : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider backMusic;
    [SerializeField] private Slider effectMusic;
    [SerializeField] private Toggle screen;

    private void Awake()
    {
        backMusic.value = PlayerPrefs.GetFloat("BackVolume", 1);
        effectMusic.value = PlayerPrefs.GetFloat("EffectVolume", 1);
        screen.enabled = System.Convert.ToBoolean(PlayerPrefs.GetInt("IsFullscreen", 1));
    }

    public void SetVolumeBackSound(float value)
    {
        mixer.SetFloat("BackVolume", (-80 + value * 100));
        PlayerPrefs.SetFloat("BackVolume", value);
    }

    public void SetVolumeEffectSound(float value)
    {
        mixer.SetFloat("EffectVolume", (-80 + value * 100));
        PlayerPrefs.SetFloat("EffectVolume", value);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("IsFullscreen", System.Convert.ToInt32(isFullscreen));
    }
}
