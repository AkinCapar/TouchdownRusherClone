using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    ChunkSpawner chunkSpawner;

    [SerializeField] private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        chunkSpawner = ChunkSpawner.instance;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ChunkEnd")
        {
            Debug.Log("YEEEEESSS");
            chunkSpawner.SpawnChunk(this.gameObject);
        }
    }
}
