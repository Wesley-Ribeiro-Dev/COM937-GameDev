using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    private string _selectedCharacter;

    public void SetCharacter(string character)
    {
        _selectedCharacter = character;
    }

    public void ChangeScene()
    {
        if (_selectedCharacter == "Rose")
            SceneManager.LoadScene("Main Scene");
    }   
}
