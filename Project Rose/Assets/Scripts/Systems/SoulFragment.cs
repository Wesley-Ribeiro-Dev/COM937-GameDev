using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFragment : MonoBehaviour
{
    private AudioSource _audioSource;
    private SounEffectsPlayer _soundEffectsPlayer;
    private CounterManager _counterManager;
    private SoulFragmentsInventory _inventory;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _soundEffectsPlayer = FindObjectOfType<SounEffectsPlayer>();
        _counterManager = FindObjectOfType<CounterManager>();
        _inventory = FindObjectOfType<GameResources>().GetInventory();
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && other.isTrigger)
        {
            AddSoulFragment();
            _counterManager.AddFragment();
            Destroy(gameObject);
            _soundEffectsPlayer.PlaySoundEffect(_audioSource.clip);
        }    
    }
    
    private void AddSoulFragment()
    {
        _inventory._soulsFragments = _inventory._soulsFragments + (1 * _counterManager.GetModifier());
    }
}
