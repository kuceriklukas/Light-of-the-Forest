using UnityEngine;
using System.Collections;

public class AudioController
{
    public void PlaySound(AudioSource audioSource)
    {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopSound(AudioSource audioSource)
    {
        audioSource.Stop();
    }
}
