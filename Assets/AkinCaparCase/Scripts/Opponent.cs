using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    GameManager gameManager;
    OpponentSpawner opponentSpawner;

    private CapsuleCollider myCollider;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        opponentSpawner = FindObjectOfType<OpponentSpawner>();
        myCollider = GetComponent<CapsuleCollider>();
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            myCollider.enabled = false;
            transform.position -= transform.forward * 5 * Time.deltaTime;
        }
    }
}
