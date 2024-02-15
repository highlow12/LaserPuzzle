using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider bgmVolumeSlider;
    public Slider sfxVolumeSlider;

    private void Update()
    {
    }
    public void setMasterVolum()
    {
        AudioManager.Instance.updateMasterVolum(masterVolumeSlider.value);
    }
    public void setBgmVolume()
    {
        AudioManager.Instance.updateBgmVolum(bgmVolumeSlider.value);
    }
    public void setsfxVolume()
    {
        AudioManager.Instance.updateSFXVolum(sfxVolumeSlider.value);
    }
}
