using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ice : MonoBehaviour
{
    private Spawner spawner;
    private Bar bar;
    private Button button;

    private void OnEnable()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(ResetGame);
    }

    public void ResetGame()
    {
        if (GameManager.GetInstance().IsGameActive())
        {
            Debug.Log("Ice clicked");
            AudioManager.GetInstance().PlayAudioSource("StatusSound", "GameOver");
            FindObjectOfType<Bar>().ResetBar();
            GameManager.GetInstance().EndGame();
        }
    }
}