using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private GameObject treePrefab;
    [SerializeField] private GameObject icePrefab;
    [SerializeField] private int pyromaniaCounter;
    [SerializeField] private Bar bar;
    [SerializeField] private GameObject pyromaniaScreen;
    private int spawnCounter;
    private int treePosIndex;

    private void OnEnable()
    {
        Spawn();
        spawnCounter = 0;
        GameManager.GetInstance().SetGameActive(true);
        
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

        
    }

    public void DestroyIce()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            foreach(Transform child in spawnPoints[i])
            {
                if (child.CompareTag("Ice"))
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }
    public void DestroyObjects()
    {
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            foreach(Transform child in spawnPoints[i])
            {
                    Destroy(child.gameObject);
            }
        }
    }

    public void SetSpawnCounter(int spawnCounter)
    {
        this.spawnCounter = spawnCounter;
    }
}