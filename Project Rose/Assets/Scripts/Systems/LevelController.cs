using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController LevelControllerInstance { get; private set; }
    private void Awake()
    {
        if (LevelControllerInstance == null)
        {
            LevelControllerInstance = FindObjectOfType<LevelController>();
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    public void TrocaLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
