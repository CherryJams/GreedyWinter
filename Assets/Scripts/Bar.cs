using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    private GameObject bar;
    [SerializeField] private float time;
    [SerializeField] private float pyromaniaTime;
    private Spawner spawner;

    // Start is called before the first frame update
    void Start()
    {
        bar = this.gameObject;
        spawner = FindObjectOfType<Spawner>();
    }

    public void AnimateBar()
    {
        ResetBar();
        if (GameManager.GetInstance().IsGameActive())
        {
            LeanTween.scaleX(bar, 0, time).setOnComplete(EndGame);
        }
    }

    public void ResetBar()
    {
        LeanTween.cancel(bar);
        LeanTween.scaleX(bar, 1, 0);
    }

    public void EndGame()
    {
        ResetBar();
        GameManager.GetInstance().EndGame();
    }

    public void SetPyromaniaTime()
    {
        time = pyromaniaTime;
    }
}