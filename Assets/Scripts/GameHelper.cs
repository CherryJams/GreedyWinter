using UnityEngine;

public class GameHelper : MonoBehaviour
{
    public void SetGameActive(bool active)
    {
        GameManager.GetInstance().SetGameActive(active);
    } 
    public void SwitchToGameUI()
    {
        CanvasManager.GetInstance().SwitchCanvas(CanvasType.GameUI);
    }
}