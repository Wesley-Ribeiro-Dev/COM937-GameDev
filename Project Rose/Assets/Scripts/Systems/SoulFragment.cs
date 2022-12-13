using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulFragment : MonoBehaviour
{
    private DropsSystem _dropSystem;

    private void Start()
    {
        _dropSystem = FindObjectOfType<DropsSystem>();
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player") && other.isTrigger)
        {
            _dropSystem.AddSoulFragment();
            Destroy(this.gameObject);
        }    
    }
}
