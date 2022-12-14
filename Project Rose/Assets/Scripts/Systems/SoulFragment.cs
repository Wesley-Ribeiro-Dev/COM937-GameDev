using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFragment : MonoBehaviour
{
    private DropsSystem _dropSystem;
    private AudioSource _audioSource;
    private SounEffectsPlayer _sounEffectsPlayer;

    private void Start()
    {
        _dropSystem = FindObjectOfType<DropsSystem>();
        _audioSource = GetComponent<AudioSource>();
        _sounEffectsPlayer = FindObjectOfType<SounEffectsPlayer>();
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && other.isTrigger)
        {
            _dropSystem.AddSoulFragment();
            Destroy(gameObject);
            _sounEffectsPlayer.PlaySoundEffect(_audioSource.clip);
        }    
    }
}
