using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    private Slider _slider;
    private Player _playerScript;
    private void Start()
    {
        _slider = GetComponent<Slider>();
        _playerScript = GetComponentInParent<Player>();
        _slider.maxValue = _playerScript.GetHealth();
    }

    public void DecreaseSlider(int value)
    {
        _slider.value -= value;
    }
}
