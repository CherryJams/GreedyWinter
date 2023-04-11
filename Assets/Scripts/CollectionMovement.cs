using UnityEngine;
public class CollectionMovement : MonoBehaviour
{
    private GameObject target;
    [SerializeField] private float timeToMove;
    public void MoveToTarget()
    {   
        target= GameObject.FindGameObjectWithTag("TreeTarget");
        LeanTween.move(gameObject, new Vector3(6.67000008f,3.03999996f,0), timeToMove); 
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), timeToMove).setOnComplete(DestroyThis);
    }

    public void DestroyThis()
    {
        Debug.Log("Destroyed tree");
        Destroy(gameObject);
    }
}