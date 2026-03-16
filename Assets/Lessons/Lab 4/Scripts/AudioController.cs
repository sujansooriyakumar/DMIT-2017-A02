using System;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private float masterVolume = 1.0f;
    private float sfxVolume = 1.0f;
    private float musicVolume = 1.0f;
    public static AudioController instance;

    public event Action OnVolumeChange;
 


    private void Awake()
    {
        instance = this;
    }

    public void SetMasterVolume(float v) { 
        masterVolume = v;
        OnVolumeChange?.Invoke();
    }
    public void SetSfxVolume(float v) { 
        sfxVolume = v; 
        OnVolumeChange?.Invoke();
    }
    public void SetMusicVolume(float v) { 
        musicVolume = v; 
        OnVolumeChange?.Invoke();
    }

    public float GetMasterVolume() { return masterVolume; }
    public float GetSfxVolume() { return sfxVolume; }
    public float GetMusicVolume() { return musicVolume; }
}
