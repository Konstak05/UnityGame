using UnityEngine;

public class AudioMain : MonoBehaviour
{

    public AudioSource SoundsSource,AmbienceSource;
    public AudioClip[] NormalSounds;
    public AudioClip[] SoundtrackSounds;
    public bool IsMuted;

    public void CloseAmbience(){AmbienceSource.enabled = false;}
    public void OpenAmbience(){AmbienceSource.enabled = true;}

    public void AudioChecker()
    {
        if(IsMuted == false){SoundsSource.volume = 1; AmbienceSource.volume = 0.5f;}
        else{SoundsSource.volume = 0; AmbienceSource.volume = 0;}
    }
}
