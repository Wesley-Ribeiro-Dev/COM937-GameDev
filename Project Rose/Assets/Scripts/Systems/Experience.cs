using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    private int _value;
    private XPBar _xpBar;

    private void Start()
    {
        _xpBar = FindObjectOfType<XPBar>();
    }
    
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            _xpBar.IncreaseXP(_value);
            Destroy(this.gameObject);
        }    
    }

    public void SetValue(int newValue)
    {
        _value = newValue;
    }
}
