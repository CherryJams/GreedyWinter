using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource audioSource;
    private Transform audioType;

    public void PlayAudioSource(string soundType, string soundName)
    {
        audioType = GameObject.FindGameObjectWithTag(soundType).transform;
        foreach (Transform child in audioType)
        {
            if(child.name == soundName)
            {
                audioSource = child.GetComponent<AudioSource>();
                audioSource.Play();
            }
        }
    }
}