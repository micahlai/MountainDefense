using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    
    
    public void ToggleMusic()
    {
        float musicVol;
        audioMixer.GetFloat("MusicVolume", out musicVol);

        if(musicVol == 0)
        {
            audioMixer.SetFloat("MusicVolume", -80);
        }
        else
        {
            audioMixer.SetFloat("MusicVolume", 0);
        }
    }
    public void ToggleSFX()
    {
        float SFXVol;
        audioMixer.GetFloat("SFXVolume", out SFXVol);

        if (SFXVol == 0)
        {
            audioMixer.SetFloat("SFXVolume", -80);
        }
        else
        {
            audioMixer.SetFloat("SFXVolume", 0);
        }
    }
    public void ToggleFullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
