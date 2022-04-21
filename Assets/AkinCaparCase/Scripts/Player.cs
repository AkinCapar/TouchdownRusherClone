using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private float elapsedTime1; // time during running fast
    private float elapsedTime2; // time during running normal

    private Animator myAnim;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        myAnim = GetComponent<Animator>();
        myAnim.SetInteger("WinCondition", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RunFast();
        }

        if (Input.GetMouseButtonUp(0))
        {
            elapsedTime1 = 0;
        }

        else if (elapsedTime1 == 0)
        {
            RunNormal();
        }
    }

    private void RunNormal()
    {
        gameManager.SwitchToNormalCam();
        Time.timeScale = 1; // to switch normal run speed

        elapsedTime2 += Time.deltaTime;
        transform.position = new Vector3(0, 0, Mathf.Lerp(transform.position.z, -1, elapsedTime2));

        if (transform.position.z > -.85f)
        {
            transform.DORotate(new Vector3(0, 90, -10), .1f);
        }

        if (transform.position.z < -.85f)
        {
            transform.DORotate(new Vector3(0, 90, 0), .1f);
        }
    }

    private void RunFast()
    {
        gameManager.SwitchToFastCam();
        Time.timeScale = 1.5f; // to make it run fast both visually and physically

        elapsedTime2 = 0;
        elapsedTime1 += Time.deltaTime;
        transform.position = new Vector3(0, 0, Mathf.Lerp(-1, 1, elapsedTime1 * 2));

        if (transform.position.z < .85f)
        {
            transform.DORotate(new Vector3(0, 90, 10), .1f);
        }

        if (transform.position.z > .85f)
        {
            transform.DORotate(new Vector3(0, 90, 0), .1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Opponent")
        {
            gameManager.LoseGame();
            myAnim.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        myAnim.SetInteger("WinCondition", Random.Range(1, 3));
        gameManager.WinGame();
    }
}
