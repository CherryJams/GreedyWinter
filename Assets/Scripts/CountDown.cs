using System;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    private float timeLeft;

    private void Start()
    {
        resetTime(2);
    }

    private void resetTime(float time)
    {
        timeLeft = time;
    }

    private void Update()
    {
        if (GameManager.GetInstance().IsGameActive())
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                GameManager.GetInstance().EndGame();
            }
        }
    }
}