using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas _gameOverCanvas;

    public void ShowGameOverScreen()
    {
        Time.timeScale = 0;
        _gameOverCanvas.gameObject.SetActive(true);
    }
}
