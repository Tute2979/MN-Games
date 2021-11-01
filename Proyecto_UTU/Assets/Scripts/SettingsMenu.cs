using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audiomixer;

    public void SetVolume (float volumeMusic)
    {
        audiomixer.SetFloat("volumeMusic", volumeMusic);
    }

    public void SetVolumeSFX(float volumeSFX)
    {
        audiomixer.SetFloat("volumeSFX", volumeSFX);
    }


}
