using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    private float elapsedTime1; // time during running fast
    private float elapsedTime2; // time during running normal

    // Start is called before the first frame update
    void Start()
    {
        
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
}
