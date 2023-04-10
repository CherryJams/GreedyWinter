using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private GameObject icePrefab;
    private int spawnCounter;
    [SerializeField] private int pyromaniaCounter;
    private int treePosIndex;

    private void OnEnable()
    {
        Spawn();
    }

    public void Spawn()
    {
        treePosIndex = Random.Range(0, spawnPoints.Count);
        var treeObject = Instantiate(treePrefab, spawnPoints[treePosIndex].position, Quaternion.identity);
        treeObject.transform.parent = spawnPoints[treePosIndex];
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (i != treePosIndex)
            {
                var iceObject = Instantiate(icePrefab, spawnPoints[i].position, Quaternion.identity);
                iceObject.transform.parent = spawnPoints[i];
            }
        }
        spawnCounter++;
        if(spawnCounter == pyromaniaCounter)
        {
            spawnCounter = 0;
        }
        
    }

    public void DestroyObjects()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            if (spawnPoints[i].GetChild(0) != null)
            {
                Destroy(spawnPoints[i].GetChild(0).gameObject);
            }
        }
    }
    
}