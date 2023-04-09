using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;


// +=========================================+
// |                                         |
// |   This script for the buttons in the    |
// |           OptionsMenu scene.            |
// |                                         |
// +=========================================+

public class SettingEvent : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private Slider backMusic;
    [SerializeField] private Slider effectMusic;
    [SerializeField] private Toggle screen;        // Full screen.
    [SerializeField] private AudioSource button;


    private void Awake()
    {
        backMusic.value = PlayerPrefs.GetFloat("BackVolume", 1);
        effectMusic.value = PlayerPrefs.GetFloat("EffectVolume", 1);
        screen.isOn = System.Convert.ToBoolean(PlayerPrefs.GetInt("IsFullscreen", 1));
    }

    // =========================== BackSound Slider =============================
    public void SetVolumeBackSound(float value)
    {
        mixer.SetFloat("BackVolume", Mathf.Log10(value) * 50);
        PlayerPrefs.SetFloat("BackVolume", value);
    }
    // ==========================================================================


    // ========================== EffectSound Slider ============================
    public void SetVolumeEffectSound(float value)
    {
        mixer.SetFloat("EffectVolume", Mathf.Log10(value) * 50);
        PlayerPrefs.SetFloat("EffectVolume", value);
    }
    // ==========================================================================


    // ========================== FullToggle Slider =============================
    public void SetFullscreen(bool isFullscreen)
    {
        button.Play();
        Screen.fullScreen = isFullscreen;
        PlayerPrefs.SetInt("IsFullscreen", System.Convert.ToInt32(isFullscreen));
    }
    // ==========================================================================

    // ==================== A Line Under Type Of Gunsight =======================
    public void SetsGunsight(int id)
    {
        PlayerPrefs.SetInt("TypeGunsight", id);
    }
    // ==========================================================================
}
