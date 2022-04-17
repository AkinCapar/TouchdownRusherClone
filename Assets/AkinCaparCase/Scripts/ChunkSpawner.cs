using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    public static ChunkSpawner instance;

    [SerializeField] private Transform spawningPlace;
    //private Queue<GameObject> chunks;
    [SerializeField] private GameObject endChunk;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void SpawnChunk(GameObject chunk)
    {
        chunk.transform.position = spawningPlace.position;
    }

    public void SpawnEndChunk()
    {
        endChunk.SetActive(true);
        endChunk.transform.position = spawningPlace.position;
    }
}
