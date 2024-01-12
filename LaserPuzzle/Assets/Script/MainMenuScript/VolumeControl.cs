using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Start()
    {
        // 초기 값 설정
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f) * 100;
        bgmVolumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 1.0f) * 100;
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1.0f) * 100;
    }

    public void SetMasterVolume(float volume)
    {
        AudioManager.Instance.SetMasterVolume(volume / 100.0f);
        PlayerPrefs.SetFloat("MasterVolume", volume / 100.0f);
    }

    public void SetBGMVolume(float volume)
    {
        AudioManager.Instance.SetBGMVolume(volume / 100.0f);
        PlayerPrefs.SetFloat("BGMVolume", volume / 100.0f);
    }

    public void SetSFXVolume(float volume)
    {
        AudioManager.Instance.SetSFXVolume(volume / 100.0f);
        PlayerPrefs.SetFloat("SFXVolume", volume / 100.0f);
    }
}
