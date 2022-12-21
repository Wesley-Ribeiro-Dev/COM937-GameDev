using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{ 
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _upgradesMenu;
    [SerializeField] private GameObject _creditsScreen;
    [SerializeField] private GameObject _controlsScreen;

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        _mainMenu.SetActive(false);
        _optionsMenu.SetActive(true);
    }

    public void CloseOptions()
    {
        _mainMenu.SetActive(true);
        _optionsMenu.SetActive(false);
    }

    public void OpenUpgrades()
    {
        _mainMenu.SetActive(false);
        _upgradesMenu.SetActive(true);
    }

    public void CloseUpgrades()
    {
        _mainMenu.SetActive(true);
        _upgradesMenu.SetActive(false);
    }
    
    public void OpenCredits()
    {
        _mainMenu.SetActive(false);
        _creditsScreen.SetActive(true);
    }

    public void CloseCredits()
    {
        _mainMenu.SetActive(true);
        _creditsScreen.SetActive(false);
    }
    
    public void OpenControls()
    {
        _mainMenu.SetActive(false);
        _controlsScreen.SetActive(true);
    }

    public void CloseControls()
    {
        _mainMenu.SetActive(true);
        _controlsScreen.SetActive(false);
    }
}
