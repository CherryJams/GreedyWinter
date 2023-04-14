using System;
using UnityEngine;
public class CollectionMovement : MonoBehaviour
{
    private RectTransform target;
    private RectTransform rectTransform;
    [SerializeField] private float timeToMove;

    private void OnEnable()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }

    public void MoveToTarget()
    {   
        target= GameObject.FindGameObjectWithTag("TreeTarget").GetComponent<RectTransform>();
        LeanTween.move(gameObject, target.localPosition, timeToMove); 
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), timeToMove).setOnComplete(DestroyThis);
    }

    public void DestroyThis()
    {
        Debug.Log("Destroyed tree");
        Destroy(gameObject);
    }
}