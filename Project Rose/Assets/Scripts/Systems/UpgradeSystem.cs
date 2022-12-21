using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystem : MonoBehaviour
{
    private GameResources _resources;
    private SoulFragmentsInventory _inventory;
    private ElixirsModifiers _elixirsModifiers;
    [SerializeField] private TextMeshProUGUI _fragmentsDisplay;
    [SerializeField] private TextMeshProUGUI _costDisplay;
    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private GameObject _errorMsg;
    void Start()
    {
        _resources = FindObjectOfType<GameResources>();
        _inventory = _resources.GetInventory();
        _elixirsModifiers = _resources.GetModifiers();
        _fragmentsDisplay.text = _inventory._soulsFragments.ToString();
        _costDisplay.text = _elixirsModifiers.cost + " fragmentos de alma";
    }

    public void CloseErrorMessage()
    {
        _errorMsg.gameObject.SetActive(false);
    }
    
    // Update is called once per frame
    public void IncreaseHealthModifier()
    {
        if (_inventory._soulsFragments >= _elixirsModifiers.cost)
        {
            _elixirsModifiers.health += 0.05f;
            _inventory._soulsFragments -= _elixirsModifiers.cost;
            _fragmentsDisplay.text = _inventory._soulsFragments.ToString();
            IncreaseUpgradeCost();
            DisplayHealthDescription();
        }
        else
        {
            _errorMsg.gameObject.SetActive(true);
        }
    }

    public void IncreaseDefenseModifier()
    {
        if (_inventory._soulsFragments >= _elixirsModifiers.cost)
        {
            _elixirsModifiers.defense += 0.05f;
            _inventory._soulsFragments -= _elixirsModifiers.cost;
            _fragmentsDisplay.text = _inventory._soulsFragments.ToString();
            IncreaseUpgradeCost();
            DisplayDefenseDescription();
        }
        else
        {
            _errorMsg.gameObject.SetActive(true);
        }
    }

    public void IncreaseDamageModifier()
    {
        if (_inventory._soulsFragments >= _elixirsModifiers.cost)
        {
            _elixirsModifiers.damage += 0.05f;
            _inventory._soulsFragments -= _elixirsModifiers.cost;
            _fragmentsDisplay.text = _inventory._soulsFragments.ToString();
            IncreaseUpgradeCost();
            DisplayDamageDescription();
        }
        else
        {
            _errorMsg.gameObject.SetActive(true);
        }
    }

    public void DisplayHealthDescription()
    {
        _description.text = "Aumente sua saúde máxima em 5% (Atualmente: " + (_elixirsModifiers.health*100) + "%)";
    }
    
    public void DisplayDefenseDescription()
    {
        _description.text = "Aumente sua defesa contra ataques em 5% (Atualmente: " + (_elixirsModifiers.defense*100) + "%)";
    }
    
    public void DisplayDamageDescription()
    {
        _description.text = "Aumente o dano causado a inimigo em 5% (Atualmente: " + (_elixirsModifiers.damage*100) + "%)";
    }

    public void IncreaseUpgradeCost()
    {
        _elixirsModifiers.cost += 10;
        _costDisplay.text = _elixirsModifiers.cost + " fragmentos de alma";
    }
}
