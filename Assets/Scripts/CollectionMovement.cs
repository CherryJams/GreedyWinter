using System;
using UnityEngine;
public class CollectionMovement : MonoBehaviour
{
    private GameObject target;
    private RectTransform rectTransform;
    [SerializeField] private float timeToMove;

    private void OnEnable()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    public void MoveToTarget()
    {   
        target= GameObject.FindGameObjectWithTag("TreeTarget");
        LeanTween.move(rectTransform, new Vector2(6.67000008f,3.03999996f), timeToMove); 
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), timeToMove).setOnComplete(DestroyThis);
    }

    public void DestroyThis()
    {
        Debug.Log("Destroyed tree");
        Destroy(gameObject);
    }
}