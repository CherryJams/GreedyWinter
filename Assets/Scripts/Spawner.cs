using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<RectTransform> spawnPoints;
    [SerializeField] private RectTransform layoutGroup;
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private GameObject icePrefab;
    [SerializeField] private int pyromaniaCounter;
    [SerializeField] private Bar bar;
    [SerializeField] private GameObject pyromaniaScreen;
    private int spawnCounter;
    private int treePosIndex;
    private GameObject treeObject;
    private GameObject iceObject;

    private void OnEnable()
    {
        Debug.Log("Spawner enabled");
        Spawn();
        spawnCounter = 0;
        GameManager.GetInstance().SetGameActive(true);
        
    }

    public void Spawn()
    {
        treePosIndex = Random.Range(0, spawnPoints.Count);
        treeObject = Instantiate(treePrefab, spawnPoints[treePosIndex].anchoredPosition, Quaternion.identity);
        treeObject.GetComponent<RectTransform>().SetParent(layoutGroup);
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (i != treePosIndex)
            {
                iceObject = Instantiate(icePrefab, spawnPoints[i].anchoredPosition, Quaternion.identity);
                iceObject.GetComponent<RectTransform>().SetParent(layoutGroup); 
            }
        }

        
    }

    public void DestroyIce()
    {
            foreach(RectTransform child in layoutGroup)
            {
              if (child.CompareTag("Ice"))
                {
                    Destroy(child.gameObject);
                }
            }
    }
    
    public void DestroyObjects()
    {
            foreach(RectTransform child in layoutGroup)
            {
                    Destroy(child.gameObject);
            }
    }

    public void SetSpawnCounter(int spawnCounter)
    {
        this.spawnCounter = spawnCounter;
    }
}