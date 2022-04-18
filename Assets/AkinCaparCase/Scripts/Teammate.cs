using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teammate : MonoBehaviour
{
    GameManager gameManager;
    TeammateSpawner teammateSpawner;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        teammateSpawner = FindObjectOfType<TeammateSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= transform.forward * gameManager.gameSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Collector")
        {
            teammateSpawner.AddToPool(gameObject);
        }
    }
}
