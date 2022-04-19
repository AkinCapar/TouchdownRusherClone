using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    GameManager gameManager;
    OpponentSpawner opponentSpawner;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        opponentSpawner = FindObjectOfType<OpponentSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * (gameManager.gameSpeed * 2) * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collector")
        {
            opponentSpawner.AddToPool(gameObject);
        }
    }
}
