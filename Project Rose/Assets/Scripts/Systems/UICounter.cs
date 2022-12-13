using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UICounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _enemiesCounter;
    [SerializeField] private TextMeshProUGUI _soulsFragmentsCounter;

    public void AddEnemies()
    {
        int currentValue = int.Parse(_enemiesCounter.text);
        currentValue++;
        _enemiesCounter.text = currentValue.ToString();
    }
    
    public void AddFragment()
    {
        int currentValue = int.Parse(_soulsFragmentsCounter.text);
        currentValue++;
        _soulsFragmentsCounter.text = currentValue.ToString();
    }
}