using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    ChunkSpawner chunkSpawner;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        chunkSpawner = ChunkSpawner.instance;
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * gameManager.gameSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collector")
        {
            chunkSpawner.SpawnChunk(this.gameObject);
        }
    }
}
