using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _enemiesCounter;
    [SerializeField] private TextMeshProUGUI _soulsFragmentsCounter;
    [SerializeField] private int _modifier = 1;

    public void AddEnemies()
    {
        int currentValue = int.Parse(_enemiesCounter.text);
        currentValue++;
        _enemiesCounter.text = currentValue.ToString();
    }
    
    public void AddFragment()
    {
        int currentValue = int.Parse(_soulsFragmentsCounter.text);
        currentValue = currentValue + (1 * _modifier);
        _soulsFragmentsCounter.text = currentValue.ToString();
    }

    public void IncreaseModifier()
    {
        _modifier++;
    }

    public int GetModifier()
    {
        return _modifier;
    }
}
