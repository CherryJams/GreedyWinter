using System;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour, IClickable
{
    [SerializeField] private int scorePoints;
    private Bar bar;
    private Score score;

    private void OnEnable()
    {
        score = FindObjectOfType<Score>();
        bar = FindObjectOfType<Bar>();
    }

    public void OnMouseDown()
    {
        bar.AnimateBar();
        score.AddScore(scorePoints);
    }
}