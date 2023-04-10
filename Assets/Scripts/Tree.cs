using System;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour, IClickable
{
    [SerializeField] private int scorePoints;
    private Bar bar;
    private Score score;
    private Spawner spawner;

    private void OnEnable()
    {
        spawner = FindObjectOfType<Spawner>();
        score = FindObjectOfType<Score>();
        bar = FindObjectOfType<Bar>();
    }

    public void OnMouseDown()
    {
        Debug.Log("Tree clicked");
        bar.AnimateBar();
        score.AddScore(scorePoints);
        spawner.DestroyObjects();
        spawner.Spawn();
    }
}