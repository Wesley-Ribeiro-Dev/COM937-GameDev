using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPBar : MonoBehaviour
{
    private Slider _slider;
    private TextMeshProUGUI _levelText;
    private int _currentLevel = 1;
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _levelText = GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        _levelText.text += _currentLevel.ToString();
    }

    public void IncreaseXP(int xp)
    {
        _slider.value += xp;
        if (_slider.value == _slider.maxValue)
        {
            _slider.value = _slider.minValue;
            _currentLevel++;
            UpdateCurrentLevel();
        }
    }

    private void UpdateCurrentLevel()
    {
        _levelText.text = "Nível: " + _currentLevel;
    }
}
