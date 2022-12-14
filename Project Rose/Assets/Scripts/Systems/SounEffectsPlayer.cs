using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SounEffectsPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySoundEffect(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}
