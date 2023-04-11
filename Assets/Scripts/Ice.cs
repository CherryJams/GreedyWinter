using Unity.VisualScripting;
using UnityEngine;

public class Ice : MonoBehaviour, IClickable
{
    private Spawner spawner;
    private Bar bar;

    public void OnMouseDown()
    {
        if (GameManager.GetInstance().IsGameActive())
        {
            Debug.Log("Ice clicked");
            FindObjectOfType<Bar>().ResetBar();
            GameManager.GetInstance().EndGame();
        }
    }
}