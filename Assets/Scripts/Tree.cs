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
    LayoutElement layoutElement;

    private void OnEnable()
    {
        layoutElement = gameObject.GetComponent<LayoutElement>();
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
            AudioManager.GetInstance().PlayAudioSource("UIAudio", "Hover");
            spawner.Spawn();
            layoutElement.ignoreLayout = true;
            bar.AnimateBar();
            score.AddScore(scorePoints);
        }
    }
}