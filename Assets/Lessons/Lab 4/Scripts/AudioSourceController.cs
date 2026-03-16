using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AudioType audioType;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        AudioController.instance.OnVolumeChange += UpdateVolume;

      
    }

    public void UpdateVolume()
    {
        switch (audioType)
        {
            case AudioType.SFX:
                audioSource.volume = AudioController.instance.GetMasterVolume() * AudioController.instance.GetSfxVolume();
                break;
                case AudioType.MUSIC:
                audioSource.volume = AudioController.instance.GetMasterVolume() * AudioController.instance.GetMusicVolume();
                break;
        }
    }


}

public enum AudioType
{
    SFX,
    MUSIC
}
