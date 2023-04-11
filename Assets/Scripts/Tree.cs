using System;
using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour, IClickable
{
    [SerializeField] private int scorePoints;
    private Bar bar;
    private CollectionMovement collectionMovement;
    private Score score;
    private Spawner spawner;

    private void OnEnable()
    {
        collectionMovement = FindObjectOfType<CollectionMovement>();
        spawner = FindObjectOfType<Spawner>();
        score = FindObjectOfType<Score>();
        bar = FindObjectOfType<Bar>();
    }

    public void OnMouseDown()
    {
        if (GameManager.GetInstance().IsGameActive())
        {
            Debug.Log("Tree clicked");
            GameManager.GetInstance().SetGameActive(true);
            spawner.DestroyIce();
            collectionMovement.MoveToTarget();
            spawner.Spawn();
            bar.AnimateBar();
            score.AddScore(scorePoints);
        }
    }
}