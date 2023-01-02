using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas _gameOverCanvas;
    [SerializeField] private Spawner _spawner;
    private float _gameTime;

    public void ShowGameOverScreen()
    {
        Time.timeScale = 0;
        _gameOverCanvas.gameObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        _gameTime += Time.fixedDeltaTime;
        int timeInSeconds = Convert.ToInt32(_gameTime % 60);
        if (timeInSeconds > 40 && _spawner.GetDelay() > 0.1f)
        {
            _gameTime = 0.0f;
            _spawner.StopSpawning();
            _spawner.DecreaseDelay();
            _spawner.SpawnEnemies();
        }
    }
}
