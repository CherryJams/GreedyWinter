using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TMP_Text scoreText;
    private int score;


    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText = gameObject.GetComponent<TMP_Text>();
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
}