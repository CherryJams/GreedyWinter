using Unity.VisualScripting;
using UnityEngine;

public class Ice : MonoBehaviour, IClickable
{
    public void OnMouseDown()
    {
        GameManager.GetInstance().EndGame();
    }
}