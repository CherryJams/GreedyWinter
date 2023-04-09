using Unity.VisualScripting;
using UnityEngine;

public class Tree : MonoBehaviour, IClickable
{
    [SerializeField] private int score = 0;

    public void OnMouseDown()
    {
        GameManager.GetInstance().StartGame();
        FindObjectOfType<Score>().AddScore(score);
    }
}