using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private GameObject arrowPrefab;

    private bool isGameActive = false;

    public void StartGame()
    {
        isGameActive = true;
    }

    public void WaitAndStartLevel()
    {
        StartCoroutine(waitAndStartLevel());
    }

    IEnumerator waitAndStartLevel()
    {
        yield return new WaitForSeconds(0.1f);
        StartGame();
    }

    public void EndGame()
    {
        isGameActive = false;
        CanvasManager.GetInstance().SwitchCanvas(CanvasType.GameOverScreen);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Victory()
    {
        CanvasManager.GetInstance().SwitchCanvas(CanvasType.EndScreen);
    }

    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void StartBurnPhase()
    {
    }

    public bool IsGameActive()
    {
        return isGameActive;
    }
}