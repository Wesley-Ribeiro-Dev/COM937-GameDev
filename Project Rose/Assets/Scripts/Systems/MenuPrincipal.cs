using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{ [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _optionsMenu;
    [SerializeField] private GameObject _upgradesMenu;

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
}
