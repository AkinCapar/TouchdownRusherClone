using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkSpawner : MonoBehaviour
{
    public static ChunkSpawner instance;

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
        chunk.transform.position = this.gameObject.transform.position;
    }

    public void SpawnEndChunk()
    {
        endChunk.SetActive(true);
        endChunk.transform.position = this.gameObject.transform.position - new Vector3(-1, 0, 0);
    }
}
