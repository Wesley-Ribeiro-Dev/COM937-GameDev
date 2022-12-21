using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class XPBar : MonoBehaviour
{
    private Slider _slider;
    private Player _player;
    private TextMeshProUGUI _levelText;
    private int _currentLevel = 1;
    private float modifier = 1;
    [SerializeField] private Canvas _upgradeCanvas;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _slider = GetComponent<Slider>();
        _levelText = GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        _levelText.text += _currentLevel.ToString();
    }

    public void IncreaseXP(int xp)
    {
        _slider.value += (xp * modifier);
        if (_slider.value == _slider.maxValue)
        {
            _slider.value = _slider.minValue;
            _currentLevel++;
            _player.CancelInvoke();
            ShowUpgradesScreen();
            UpdateCurrentLevel();
            IncreaseXpRequired();
        }
    }
    
    public void ShowUpgradesScreen()
    {
        Time.timeScale = 0;
        _upgradeCanvas.gameObject.SetActive(true);
    }

    private void UpdateCurrentLevel()
    {
        _levelText.text = "Nível: " + _currentLevel;
    }
    
    public void IncreaseXPAmount(float value)
    {
        modifier *= value;
    }

    public void IncreaseXpRequired()
    {
        _slider.maxValue = (_slider.maxValue * 0.1f) + _slider.maxValue;
    }
}
