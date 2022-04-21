using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teammate : MonoBehaviour
{
    GameManager gameManager;
    TeammateSpawner teammateSpawner;

    private float teammateSpeedModifier = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        teammateSpawner = FindObjectOfType<TeammateSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.endChunkSpawned == true)
        {
            transform.position += transform.forward * gameManager.gameSpeed * .25f * Time.deltaTime;
        }

        else
        {
            transform.position -= transform.forward * (gameManager.gameSpeed * teammateSpeedModifier) * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collector")
        {
            teammateSpawner.AddToPool(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Teammate")
        {
            teammateSpeedModifier = 0;
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Teammate")
        {
            teammateSpeedModifier = 0.8f;
        }
    }
}
