using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour
{
    [SerializeField] private int scorePoints;
    private Bar bar;
    private CollectionMovement collectionMovement;
    private Score score;
    private Spawner spawner;
    private Button button;

    private void OnEnable()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(AdvanceGame);
        collectionMovement = FindObjectOfType<CollectionMovement>();
        spawner = FindObjectOfType<Spawner>();
        score = FindObjectOfType<Score>();
        bar = FindObjectOfType<Bar>();
    }

    public void AdvanceGame()
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