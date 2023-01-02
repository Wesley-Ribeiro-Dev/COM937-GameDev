using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = System.Random;

public class XPBar : MonoBehaviour
{
    private Slider _slider;
    private Player _player;
    private TextMeshProUGUI _levelText;
    private int _currentLevel = 1;
    private float modifier = 1;
    [SerializeField] private Canvas _upgradeCanvas1;
    [SerializeField] private Canvas _upgradeCanvas2;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _slider = GetComponent<Slider>();
        _levelText = GetComponentInChildren(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        _levelText.text += _currentLevel.ToString();
    }

    public void IncreaseXP(int xp)
    {
        if (_player.GetHealth() > 0)
        {
            _slider.value += (xp * modifier);
            if (_slider.value == _slider.maxValue)
            {
                _slider.value = _slider.minValue;
                _currentLevel++;
                _player.CancelInvoke();
                UpdateCurrentLevel();
                IncreaseXpRequired();
                Random r = new Random();
                int option = r.Next(0, 2);
                if (option == 0)
                    ShowUpgradesScreen1();
                else
                    ShowUpgradesScreen2();

            }
        }
    }
    
    public void ShowUpgradesScreen1()
    {
        Time.timeScale = 0;
        _upgradeCanvas1.gameObject.SetActive(true);
    }
    
    public void ShowUpgradesScreen2()
    {
        Time.timeScale = 0;
        _upgradeCanvas2.gameObject.SetActive(true);
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
